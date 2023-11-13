using Doss.Core.Domain.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.Property(p => p.BankStatus).HasColumnType("varchar").HasMaxLength(100);
        builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(200);
    }
}