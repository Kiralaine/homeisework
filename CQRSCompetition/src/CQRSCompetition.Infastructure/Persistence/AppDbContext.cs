using CQRSCompetition.Domain.Entities;
using CQRSCompetition.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSCompetition.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Competition> Competitions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
    }
}