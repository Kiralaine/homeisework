using CQRSCouch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSCouch.Infastructure.Persistence.Configurations;

public class CouchConfiguration : IEntityTypeConfiguration<Couch>
{
    public void Configure(EntityTypeBuilder<Couch> builder)
    {
        builder.ToTable("Couchs");
        builder.HasKey(x => x.Id);
    }
}