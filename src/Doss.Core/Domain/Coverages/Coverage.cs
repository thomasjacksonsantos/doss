using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Coverages;

public class Coverage
{
    public Guid Id { get; set; }
    public CoverageStatus CoverageStatus { get; set; }
    public DateTime Created { get; set; }
}