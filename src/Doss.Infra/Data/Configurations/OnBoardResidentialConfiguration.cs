using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardResidentialConfiguration : IEntityTypeConfiguration<OnBoardResidential>
{
    public void Configure(EntityTypeBuilder<OnBoardResidential> builder)
    {
        builder.Property(p => p.Step).HasConversion<string>();
        builder.Property(p => p.Step).HasColumnType("varchar").HasMaxLength(20);
    }
}