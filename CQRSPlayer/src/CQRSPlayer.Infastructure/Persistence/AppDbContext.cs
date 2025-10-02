using CQRSPlayer.Domain.Entities;
using CQRSPlayer.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSPlayer.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
    }
}