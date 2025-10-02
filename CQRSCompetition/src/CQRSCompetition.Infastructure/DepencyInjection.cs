using CQRSCompetition.APP.Interfaces;
using CQRSCompetition.Infastructure.Persistence;
using CQRSCompetition.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSCompetition.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<ICompetitionWriteRepository, CompetitionWriteRepository>();
        services.AddScoped<ICompetitionReadRepository, CompetitionReadRepository>();

        return services;
    }
}