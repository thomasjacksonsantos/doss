using Doss.Core.Domain.Users;

namespace Doss.Core.Interfaces.Repositories;

public interface IResidentialRepository : IRepositoryBase<Residential>
{
    Task<Residential> ReturnResidentialByIdAsync(Guid userId);
}