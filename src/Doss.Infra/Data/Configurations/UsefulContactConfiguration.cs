using Doss.Core.Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class UsefulContactConfiguration : IEntityTypeConfiguration<UsefulContact>
{
    public void Configure(EntityTypeBuilder<UsefulContact> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.Number).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Status).HasConversion<string>().HasColumnType("varchar").HasMaxLength(50);
    }
}