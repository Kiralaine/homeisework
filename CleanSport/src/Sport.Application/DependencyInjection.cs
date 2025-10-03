using Sport.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Sport.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISportService, SportService>();

        return services;
    }
}