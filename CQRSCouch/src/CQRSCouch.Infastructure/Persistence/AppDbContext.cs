using CQRSCouch.Domain.Entities;
using CQRSCouch.Infastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSCouch.Infastructure.Persistence;
public class AppDbContext : DbContext
{
    public DbSet<Couch> Couchs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CouchConfiguration());
    }
}