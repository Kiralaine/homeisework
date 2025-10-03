using Show.Domain.Entities;
using Show.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Show.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ShowConfiguration());
    }
}
