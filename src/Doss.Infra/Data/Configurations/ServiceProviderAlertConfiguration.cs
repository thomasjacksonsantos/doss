using Doss.Core.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ServiceProviderAlertConfiguration : IEntityTypeConfiguration<ServiceProviderAlert>
{
    public void Configure(EntityTypeBuilder<ServiceProviderAlert> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(100);
    }
}