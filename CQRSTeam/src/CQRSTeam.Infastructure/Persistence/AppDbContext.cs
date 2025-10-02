using CQRSTeam.Domain.Entities;
using CQRSTeam.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSTeam.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
    }
}