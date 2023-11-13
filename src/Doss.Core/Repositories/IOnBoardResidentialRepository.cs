
using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Interfaces.Repositories;

public interface IOnBoardResidentialRepository : IRepositoryBase<OnBoardResidential>
{
    Task<OnBoardResidential> ReturnByUserIdAsync(Guid userId);
}