using Doss.Core.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ServiceProviderPlanConfiguration : IEntityTypeConfiguration<ServiceProviderPlan>
{
    public void Configure(EntityTypeBuilder<ServiceProviderPlan> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.AgencyBank).HasColumnType("varchar").HasMaxLength(160);
        builder.Property(p => p.AccountBank).HasColumnType("varchar").HasMaxLength(160);
        builder.OwnsOne(p => p.Address, address =>
        {
            address.Property(a => a.Country).HasColumnName("Address_Country").HasColumnType("varchar").HasMaxLength(20);
            address.Property(a => a.State).HasColumnName("Address_State").HasColumnType("varchar").HasMaxLength(20);
            address.Property(a => a.City).HasColumnName("Address_City").HasColumnType("varchar").HasMaxLength(30);
            address.Property(a => a.Street).HasColumnName("Address_Street").HasColumnType("varchar").HasMaxLength(200);
            address.Property(a => a.Neighborhood).HasColumnName("Address_Neighborhood").HasColumnType("varchar").HasMaxLength(200);
            address.Property(a => a.Complement).HasColumnName("Address_Complement").HasColumnType("varchar").HasMaxLength(200);
            address.Property(a => a.ZipCode).HasColumnName("Address_ZipCode").HasColumnType("varchar").HasMaxLength(20);
            address.Property(a => a.Number).HasColumnName("Address_Number").HasColumnType("varchar").HasMaxLength(20);
            address.Property(a => a.Latitude).HasColumnName("Address_Latitude");
            address.Property(a => a.Longitude).HasColumnName("Address_Longitude");
            
        });
    }
}