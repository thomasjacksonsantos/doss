
using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Coverages;

namespace Doss.Infra.Repositories;

public class CoverageRepository : RepositoryBase<Coverage>, ICoverageRepository
{
    public CoverageRepository(DossDbContext context)
        : base(context)
    {

    }
}