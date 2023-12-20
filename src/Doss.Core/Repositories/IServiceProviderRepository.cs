using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;

namespace Doss.Core.Interfaces.Repositories;

public interface IServiceProviderRepository : IRepositoryBase<ServiceProvider>
{
    Task<IEnumerable<ServiceProvider>> ReturnByZipCodeAsync(string zipCode);
    Task<IEnumerable<Plan>> ReturnPlanAll(Guid serviceProviderId);
    Task<ServiceProviderPlan> ReturnServiceProviderPlan(Guid id);
    Task UpdateServiceProviderStatus(Guid id, UserStatus userStatus);
    Task<ServiceProvider> ReturnVehiclesAll(Guid serviceProviderId);
}