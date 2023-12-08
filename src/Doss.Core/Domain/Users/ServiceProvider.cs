using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Plans;

namespace Doss.Core.Domain.Users;

public class ServiceProvider : User
{
    public IEnumerable<ServiceProviderPlan> ServiceProviderPlans { get; private set; } = new List<ServiceProviderPlan>();

    public ServiceProvider(Guid userId, string name, TypeDocument typeDocument, string document, string phone, string photo, bool completedRegistration)
        : base(userId, name, typeDocument, document, phone, photo, completedRegistration) { }

    public Plan ReturnPlanById(Guid planId)
        => ServiceProviderPlans!.SelectMany(c => c.Plans)
                .SingleOrDefault(c => c.Id == planId)!;

    public void AddServiceProviderPlan(ServiceProviderPlan serviceProviderPlan)
        => ((List<ServiceProviderPlan>)ServiceProviderPlans).Add(serviceProviderPlan);
}