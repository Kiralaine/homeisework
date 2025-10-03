using Festival.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Festival.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IFestivalService, FestivalService>();

        return services;
    }
}