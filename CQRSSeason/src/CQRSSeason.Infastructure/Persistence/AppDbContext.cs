using CQRSSeason.Domain.Entities;
using CQRSSeason.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSSeason.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Season> Seasons { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SeasonConfiguration());
    }
}