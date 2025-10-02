using CQRSSport.Domain.Entities;
using CQRSSport.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSSport.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Sport> Sports { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SportConfiguration());
    }
}