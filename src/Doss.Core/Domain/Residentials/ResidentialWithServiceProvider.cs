using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;

namespace Doss.Core.Domain.Residentials;

public class ResidentialWithServiceProvider
{
    public Guid ResidentialId { get; set; }
    public Residential Residential { get; set; } = null!;
    public Guid ServiceProviderId { get; set; }
    public ServiceProvider ServiceProvider { get; set; } = null!;
    public Guid PlanId { get; set; }
    public Plan Plan { get; set; } = null!;

    public ResidentialWithServiceProvider(Guid residentialId, Guid serviceProviderId, Guid planId)
        => (ResidentialId, ServiceProviderId, PlanId) = (residentialId, serviceProviderId, planId);
}