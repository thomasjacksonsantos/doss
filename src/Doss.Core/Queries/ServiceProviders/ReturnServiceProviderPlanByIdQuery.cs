using Doss.Core.Domain.Plans;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ReturnServiceProviderPlanByIdQuery : Query<IEnumerable<Plan>>
{
    public Guid Id { get; set; }
}