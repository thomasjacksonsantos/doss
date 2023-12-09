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
    }
}