using Microsoft.Extensions.DependencyInjection;
using MongoStudent.App.Interfaces;
using MongoStudent.App.Services;

namespace MongoStudent.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();

        return services;
    }
}