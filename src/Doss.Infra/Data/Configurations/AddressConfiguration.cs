using Doss.Core.Domain.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Country).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.State).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.City).HasColumnType("varchar").HasMaxLength(30);
        builder.Property(p => p.Street).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.ZipCode).HasColumnType("varchar").HasMaxLength(10);
        builder.Property(p => p.Latitude);
        builder.Property(p => p.Longitude);
    }
}