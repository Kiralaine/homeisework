using CQRSCouch.APP.Interfaces;
using CQRSCouch.Infastructure.Persistence;
using CQRSCouch.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSCouch.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<ICouchWriteRepository, CouchWriteRepository>();
        services.AddScoped<ICouchReadRepository, CouchReadRepository>();

        return services;
    }
}