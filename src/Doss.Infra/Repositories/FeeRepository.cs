
using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Fees;

namespace Doss.Infra.Repositories;

public class FeeRepository : RepositoryBase<Fee>, IFeeRepository
{
    public FeeRepository(DossDbContext context)
        : base(context)
    {

    }

    public Task<Fee> ReturnFee()
    {
        throw new NotImplementedException();
    }
}