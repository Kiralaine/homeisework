using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoUser.App.Interfaces;
using MongoUser.Domain;
using MongoUser.Inf.Persistence.Repository;

namespace MongoUser.Inf;

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
        services.AddSingleton<IMongoCollection<User>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<User>("Users");
        });

        // Register Repository
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}