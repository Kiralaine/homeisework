using CQRSFestival.APP.Interfaces;
using CQRSFestival.Infastructure.Persistence;
using CQRSFestival.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSFestival.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<IFestivalWriteRepository, FestivalWriteRepository>();
        services.AddScoped<IFestivalReadRepository, FestivalReadRepository>();

        return services;
    }
}