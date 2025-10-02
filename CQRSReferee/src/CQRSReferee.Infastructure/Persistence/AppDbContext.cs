using CQRSReferee.Domain.Entities;
using CQRSReferee.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSReferee.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Referee> Referees { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RefereeConfiguration());
    }
}