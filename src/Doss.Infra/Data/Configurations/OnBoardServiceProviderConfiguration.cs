using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardServiceProviderConfiguration : IEntityTypeConfiguration<OnBoardServiceProvider>
{
    public void Configure(EntityTypeBuilder<OnBoardServiceProvider> builder)
    {
        builder.Property(p => p.Step).HasConversion<string>();
        builder.Property(p => p.Step).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.AccountBank).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.AgencyBank).HasColumnType("varchar").HasMaxLength(20);
    }
}