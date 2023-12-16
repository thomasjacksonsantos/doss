using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;

namespace Doss.Core.Domain.Residentials;

public class ResidentialWithServiceProvider
{
    public Guid Id { get; set; }
    public Guid ResidentialId { get; set; }
    public Residential Residential { get; set; }
    public Guid ServiceProviderPlanId { get; set; }
    public ServiceProviderPlan ServiceProviderPlan { get; set; } = null!;
    public Address Address { get; set; }
    public ResidentialWithServiceProvider()
    {

    }
    public ResidentialWithServiceProvider(Guid serviceProviderPlanId, Address address)
        => (ServiceProviderPlanId, Address) = (serviceProviderPlanId, address);
}