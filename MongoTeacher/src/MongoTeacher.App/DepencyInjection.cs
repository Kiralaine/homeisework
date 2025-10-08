using Microsoft.Extensions.DependencyInjection;
using MongoTeacher.App.Interfaces;
using MongoTeacher.App.Services;

namespace MongoTeacher.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();

        return services;
    }
}