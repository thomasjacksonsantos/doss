using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class BrandVehicleConfiguration : IEntityTypeConfiguration<BrandVehicle>
{
    public void Configure(EntityTypeBuilder<BrandVehicle> builder)
    {
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(100);
    }
}