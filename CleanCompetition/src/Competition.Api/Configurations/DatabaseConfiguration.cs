using System;
using Competition.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Competition.Api.Configurations;

public static class DatabaseConfiguration
{
    public static void ConfigureDB(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString));
    }
}
