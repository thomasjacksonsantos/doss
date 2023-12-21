using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardAddressConfiguration : IEntityTypeConfiguration<OnBoardAddress>
{
    public void Configure(EntityTypeBuilder<OnBoardAddress> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Country).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.State).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.City).HasColumnType("varchar").HasMaxLength(30);
        builder.Property(p => p.Street).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.ZipCode).HasColumnType("varchar").HasMaxLength(10);
        builder.Property(p => p.Neighborhood).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.Complement).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.Number).HasColumnType("varchar").HasMaxLength(30);
        builder.Property(p => p.Latitude);
        builder.Property(p => p.Longitude);
    }
}