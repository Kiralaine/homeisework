using CQRSShow.APP.Interfaces;
using CQRSShow.Infastructure.Persistence;
using CQRSShow.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSShow.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<IShowWriteRepository, ShowWriteRepository>();
        services.AddScoped<IShowReadRepository, ShowReadRepository>();

        return services;
    }
}