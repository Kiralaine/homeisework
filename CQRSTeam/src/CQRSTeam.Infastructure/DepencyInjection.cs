using CQRSTeam.APP.Interfaces;
using CQRSTeam.Infastructure.Persistence;
using CQRSTeam.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSTeam.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<ITeamWriteRepository, TeamWriteRepository>();
        services.AddScoped<ITeamReadRepository, TeamReadRepository>();

        return services;
    }
}