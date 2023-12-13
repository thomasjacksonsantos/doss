using Doss.Core.Domain.Verifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(c => c.Status)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        builder.Property(c => c.Message)
                .HasColumnType("varchar")
                .HasMaxLength(200);
    }
}