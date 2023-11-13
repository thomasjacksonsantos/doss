using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardUserConfiguration : IEntityTypeConfiguration<OnBoardUser>
{
    public void Configure(EntityTypeBuilder<OnBoardUser> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.UserId);
        builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(600);
        builder.Property(p => p.Document).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Phone).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Photo).HasColumnType("text");
    }
}