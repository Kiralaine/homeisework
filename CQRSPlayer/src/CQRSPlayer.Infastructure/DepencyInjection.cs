using CQRSPlayer.APP.Interfaces;
using CQRSPlayer.Infastructure.Persistence;
using CQRSPlayer.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSPlayer.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<IPlayerWriteRepository, PlayerWriteRepository>();
        services.AddScoped<IPlayerReadRepository, PlayerReadRepository>();

        return services;
    }
}