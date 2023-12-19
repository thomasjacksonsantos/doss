using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ServiceProviderVehicleConfiguration : IEntityTypeConfiguration<ServiceProviderVehicle>
{
    public void Configure(EntityTypeBuilder<ServiceProviderVehicle> builder)
    {
        builder.HasKey(p => p.Id);
    }
}