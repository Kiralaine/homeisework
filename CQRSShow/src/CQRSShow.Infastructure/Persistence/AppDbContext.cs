using CQRSShow.Domain.Entities;
using CQRSShow.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSShow.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Show> Shows { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ShowConfiguration());
    }
}