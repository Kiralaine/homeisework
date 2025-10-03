using Season.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Season.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISeasonService, SeasonService>();

        return services;
    }
}