using Competition.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Competition.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICompetitionService, CompetitionService>();

        return services;
    }
}