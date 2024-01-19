using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Color).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(p => p.Photo).HasColumnType("text");
        builder.Property(p => p.Plate).HasColumnType("varchar").HasMaxLength(20);
    }
}