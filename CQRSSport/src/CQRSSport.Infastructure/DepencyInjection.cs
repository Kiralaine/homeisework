using CQRSSport.APP.Interfaces;
using CQRSSport.Infastructure.Persistence;
using CQRSSport.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSSport.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<ISportWriteRepository, SportWriteRepository>();
        services.AddScoped<ISportReadRepository, SportReadRepository>();

        return services;
    }
}