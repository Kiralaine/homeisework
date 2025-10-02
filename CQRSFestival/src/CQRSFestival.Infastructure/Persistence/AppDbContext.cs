using CQRSFestival.Domain.Entities;
using CQRSFestival.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSFestival.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Festival> Festivals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FestivalConfiguration());
    }
}