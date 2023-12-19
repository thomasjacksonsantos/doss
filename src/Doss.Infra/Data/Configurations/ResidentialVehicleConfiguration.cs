using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ResidentialVehicleConfiguration : IEntityTypeConfiguration<ResidentialVehicle>
{
    public void Configure(EntityTypeBuilder<ResidentialVehicle> builder)
    {
        builder.HasKey(p => p.Id);
    }
}