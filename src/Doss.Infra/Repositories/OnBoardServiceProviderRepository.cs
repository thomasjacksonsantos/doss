using Doss.Infra.Data;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Domain.Banks;

namespace Doss.Infra.Repositories;

public class OnBoardServiceProviderRepository : RepositoryBase<OnBoardServiceProvider>, IOnBoardServiceProviderRepository
{
    public OnBoardServiceProviderRepository(DossDbContext context)
        : base(context) { }

    public async Task<OnBoardServiceProvider> ReturnByUserIdAsync(Guid userId)
        => await Context.OnBoardServiceProvider
                        .Include(c => c.User)
                        .Include(c => c.Address)
                        .Include(c => c.Plans)
                        .Include(c => c.Vehicle)
                        .Include(c => c.Bank)
                        .FirstOrDefaultAsync(c => c.User.UserId == userId) ?? null!;

    public void RemovePlans(IEnumerable<OnBoardPlan> plans)
        => Context.RemoveRange(plans);

    public void RemoveBank(Bank bank)
        => Context.Remove(bank);
}