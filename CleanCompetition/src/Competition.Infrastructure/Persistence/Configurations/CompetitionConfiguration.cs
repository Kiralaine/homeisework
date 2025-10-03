using Competition.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Competition.Infrastructure.Persistence.Configurations;

public class CompetitionConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Competitions");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Content)
            .IsRequired();

        builder.Property(b => b.Tags)
            .HasMaxLength(500);

        builder.Property(b => b.PublishedDate)
            .IsRequired();

        builder.Property(b => b.Likes).HasDefaultValue(0);
        builder.Property(b => b.Views).HasDefaultValue(0);
        builder.Property(b => b.CommentsCount).HasDefaultValue(0);
    }
}