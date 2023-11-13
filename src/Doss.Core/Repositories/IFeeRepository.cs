using Doss.Core.Domain.Fees;

namespace Doss.Core.Interfaces.Repositories;

public interface IFeeRepository : IRepositoryBase<Fee>
{
    Task<Fee> ReturnFee();
}