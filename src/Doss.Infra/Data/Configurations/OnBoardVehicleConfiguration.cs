using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardVehicleConfiguration : IEntityTypeConfiguration<OnBoardVehicle>
{
    public void Configure(EntityTypeBuilder<OnBoardVehicle> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Brand).HasColumnType("varchar").HasMaxLength(200);
        builder.Property(p => p.Color).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(p => p.Photo).HasColumnType("text");
        builder.Property(p => p.Model).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(p => p.Plate).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.VehicleType).HasConversion<string>();
        builder.Property(p => p.VehicleType).HasColumnType("varchar").HasMaxLength(20);
    }
}