using Festival.Domain.Entities;
using Festival.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Festival.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FestivalConfiguration());
    }
}
