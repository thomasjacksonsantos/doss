using Doss.Core.Domain.Addresses;
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
    public Address Address { get; set; }
    public ResidentialWithServiceProvider()
    {

    }
    public ResidentialWithServiceProvider(Guid residentialId, Guid serviceProviderId, Guid planId, Address address)
        => (ResidentialId, ServiceProviderId, PlanId, Address) = (residentialId, serviceProviderId, planId, address);
}