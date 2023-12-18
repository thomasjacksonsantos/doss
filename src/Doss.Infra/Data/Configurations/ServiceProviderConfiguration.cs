using Doss.Core.Domain.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
{
    public void Configure(EntityTypeBuilder<ServiceProvider> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(600);
        builder.Property(p => p.Document).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Photo).HasColumnType("text");
        builder.Property(p => p.Phone).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.UserStatus).HasConversion<string>();
        builder.Property(p => p.UserStatus).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.TypeDocument).HasConversion<string>().HasColumnType("varchar").HasMaxLength(16);
    }
}