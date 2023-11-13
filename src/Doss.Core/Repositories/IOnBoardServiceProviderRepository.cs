
using Doss.Core.Domain.Banks;
using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Interfaces.Repositories;

public interface IOnBoardServiceProviderRepository : IRepositoryBase<OnBoardServiceProvider>
{
    Task<OnBoardServiceProvider> ReturnByUserIdAsync(Guid userId);
    void RemovePlans(IEnumerable<OnBoardPlan> plans);
    void RemoveBank(Bank bank);
}