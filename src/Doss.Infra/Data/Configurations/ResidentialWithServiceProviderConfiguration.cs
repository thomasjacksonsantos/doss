using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ResidentialWithServiceProviderConfiguration : IEntityTypeConfiguration<ResidentialWithServiceProvider>
{
    public void Configure(EntityTypeBuilder<ResidentialWithServiceProvider> builder)
    {
        builder.HasKey(c => new { c.ResidentialId, c.ServiceProviderId, c.PlanId });
        builder.Property(c => c.ResidentialId);
        builder.Property(c => c.ServiceProviderId);
        builder.Property(c => c.PlanId);
    }
}