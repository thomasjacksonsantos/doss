using Doss.Infra.Data;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class OnBoardResidentialRepository : RepositoryBase<OnBoardResidential>, IOnBoardResidentialRepository
{
    public OnBoardResidentialRepository(DossDbContext context)
        : base(context) { }

    public override async Task<OnBoardResidential> ReturnByIdAsync(Guid userId)
        => await Context.OnBoardResidential
                        .Include(c => c.OnBoardUser)
                        .Include(c => c.Address)
                        .Include(c => c.ServiceProviderPlan)
                        .Include(c => c.Plan)
                        .FirstOrDefaultAsync(c => c.TokenUserId == userId) ?? null!;
}