using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Residentials;

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