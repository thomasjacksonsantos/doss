using Doss.Core.Domain.OnBoard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doss.Infra.Data.Configuration;

public class OnBoardServiceProviderPlanConfiguration : IEntityTypeConfiguration<OnBoardPlan>
{
    public void Configure(EntityTypeBuilder<OnBoardPlan> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(200);
    }
}