using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class VerificationMessageConfiguration : IEntityTypeConfiguration<VerificationMessage>
{
    public void Configure(EntityTypeBuilder<VerificationMessage> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Message).HasConversion<string>().HasColumnType("varchar").HasMaxLength(4000);
        builder.Property(p => p.PhotoUrl).HasConversion<string>().HasColumnType("varchar").HasMaxLength(1000);
        builder.Property(p => p.Photo).HasConversion<string>().HasColumnType("text");
        builder.Property(p => p.Audio).HasConversion<string>().HasColumnType("text");
    }
}