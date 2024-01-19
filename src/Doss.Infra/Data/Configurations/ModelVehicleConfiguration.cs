using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ModelVehicleConfiguration : IEntityTypeConfiguration<ModelVehicle>
{
    public void Configure(EntityTypeBuilder<ModelVehicle> builder)
    {
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(100);
    }
}