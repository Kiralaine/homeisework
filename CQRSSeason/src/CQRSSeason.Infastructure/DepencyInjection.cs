using CQRSSeason.APP.Interfaces;
using CQRSSeason.Infastructure.Persistence;
using CQRSSeason.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSSeason.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<ISeasonWriteRepository, SeasonWriteRepository>();
        services.AddScoped<ISeasonReadRepository, SeasonReadRepository>();

        return services;
    }
}