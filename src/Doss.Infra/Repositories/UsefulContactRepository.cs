using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Contacts;

namespace Doss.Infra.Repositories;

public class UsefulContactRepository : RepositoryBase<UsefulContact>, IUsefulContactRepository
{
    public UsefulContactRepository(DossDbContext context)
        : base(context)
    {

    }
}