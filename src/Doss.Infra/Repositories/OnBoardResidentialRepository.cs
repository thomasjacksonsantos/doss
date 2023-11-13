using Doss.Infra.Data;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class OnBoardResidentialRepository : RepositoryBase<OnBoardResidential>, IOnBoardResidentialRepository
{
    public OnBoardResidentialRepository(DossDbContext context)
        : base(context) { }

    public async Task<OnBoardResidential> ReturnByUserIdAsync(Guid userId)
        => await Context.OnBoardResidential
                        .Include(c => c.User)
                        .Include(c => c.Address)
                        .Include(c => c.ServiceProvider)
                        .Include(c => c.Plan)
                        .FirstOrDefaultAsync(c => c.User.UserId == userId) ?? null!;
}