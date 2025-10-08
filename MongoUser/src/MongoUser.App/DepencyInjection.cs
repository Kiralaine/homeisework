using Microsoft.Extensions.DependencyInjection;
using MongoUser.App.Interfaces;
using MongoUser.App.Services;

namespace MongoUser.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}