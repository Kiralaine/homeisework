using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoTeacher.App.Interfaces;
using MongoTeacher.Domain;
using MongoTeacher.Inf.Persistence.Repository;

namespace MongoTeacher.Inf;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure MongoDB
        services.AddSingleton<IMongoClient>(sp =>
        {
            var connectionString = configuration.GetConnectionString("MongoDB");
            return new MongoClient(connectionString);
        });

        // Configure MongoDB Database and Collection
        services.AddSingleton(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            var databaseName = configuration["MongoDB:DatabaseName"];
            return mongoClient.GetDatabase(databaseName);
        });

        // Register MongoDB Collection
        services.AddSingleton<IMongoCollection<Teacher>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<Teacher>("Teachers");
        });

        // Register Repository
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        return services;
    }
}