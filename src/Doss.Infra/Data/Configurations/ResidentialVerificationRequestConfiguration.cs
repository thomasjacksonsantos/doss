using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ResidentialVerificationRequestConfiguration : IEntityTypeConfiguration<ResidentialVerificationRequest>
{
    public void Configure(EntityTypeBuilder<ResidentialVerificationRequest> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Status).HasConversion<string>().HasColumnType("varchar").HasMaxLength(100);
        builder.Property(p => p.Message).HasConversion<string>().HasColumnType("varchar").HasMaxLength(300);
    }
}