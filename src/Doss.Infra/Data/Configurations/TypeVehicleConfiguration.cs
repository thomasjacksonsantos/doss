using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class TypeVehicleConfiguration : IEntityTypeConfiguration<TypeVehicle>
{
    public void Configure(EntityTypeBuilder<TypeVehicle> builder)
    {
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(100);
    }
}