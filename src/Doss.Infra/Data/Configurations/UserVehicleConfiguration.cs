using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class UserVehicleConfiguration : IEntityTypeConfiguration<UserVehicle>
{
    public void Configure(EntityTypeBuilder<UserVehicle> builder)
    {
        builder.HasKey(p => p.Id);
    }
}