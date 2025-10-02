using CQRSReferee.APP.Interfaces;
using CQRSReferee.Infastructure.Persistence;
using CQRSReferee.Infastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSReferee.Infastructure;

public static class DepencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(sqlConnectionString));

        services.AddScoped<IRefereeWriteRepository, RefereeWriteRepository>();
        services.AddScoped<IRefereeReadRepository, RefereeReadRepository>();

        return services;
    }
}