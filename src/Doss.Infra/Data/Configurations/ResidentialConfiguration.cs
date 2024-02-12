using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ResidentialConfiguration : IEntityTypeConfiguration<Residential>
{
    public void Configure(EntityTypeBuilder<Residential> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(600);
        builder.Property(p => p.Document).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.PhotoUrl).HasConversion<string>().HasColumnType("varchar").HasMaxLength(1000);
        builder.Property(p => p.Phone).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.UserStatus)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .HasConversion(v => v.ToString(),
                               v => (UserStatus)Enum.Parse(typeof(UserStatus), v));

        builder.Property(p => p.TypeDocument)
                .HasColumnType("varchar").HasMaxLength(16)
                .HasConversion(v => v.ToString(),
                               v => (TypeDocument)Enum.Parse(typeof(TypeDocument), v));
    }
}