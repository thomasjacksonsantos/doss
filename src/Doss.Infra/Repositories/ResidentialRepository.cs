using Doss.Infra.Data;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;

namespace Doss.Infra.Repositories;

public class ResidentialRepository : RepositoryBase<Residential>, IResidentialRepository
{
    public ResidentialRepository(DossDbContext context)
        : base(context)
    {

    }

    public Task<Residential> ReturnResidentialByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}