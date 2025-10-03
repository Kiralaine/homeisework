using Show.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Show.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IShowService, ShowService>();

        return services;
    }
}