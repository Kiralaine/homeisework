using Season.Domain.Entities;
using Season.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Season.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SeasonConfiguration());
    }
}
