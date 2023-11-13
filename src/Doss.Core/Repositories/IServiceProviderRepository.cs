using Doss.Core.Domain.Plans;
using Doss.Core.Domain.Users;

namespace Doss.Core.Interfaces.Repositories;

public interface IServiceProviderRepository : IRepositoryBase<ServiceProvider>
{
    Task<ServiceProvider> ReturnByUserIdAsync(Guid userId);
    Task<IEnumerable<ServiceProvider>> ReturnByZipCodeAsync(string zipCode);
    Task<IEnumerable<Plan>> ReturnPlanAll(Guid serviceProviderId);
}