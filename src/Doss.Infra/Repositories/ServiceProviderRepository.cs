using Doss.Infra.Data;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Domain.Plans;

namespace Doss.Infra.Repositories;

public class ServiceProviderRepository : RepositoryBase<ServiceProvider>, IServiceProviderRepository
{
    public ServiceProviderRepository(DossDbContext context)
        : base(context)
    {

    }

    public override async Task<ServiceProvider> ReturnByIdAsync(Guid id)
        => await Context.ServiceProvider
                        .Include(c => c.ServiceProviderPlans)
                        .AsSplitQuery()
                        .SingleOrDefaultAsync(c => c.Id == id) ?? null!;

    public async Task<ServiceProvider> ReturnByUserIdAsync(Guid userId)
        => await Context.ServiceProvider
                        .Include(c => c.ServiceProviderPlans)
                        .AsSplitQuery()
                        .SingleOrDefaultAsync(c => c.UserId == userId) ?? null!;

    public async Task<IEnumerable<ServiceProvider>> ReturnByZipCodeAsync(string zipCode)
        => await Context.ServiceProvider.ToListAsync();

    public async Task<IEnumerable<Plan>> ReturnPlanAll(Guid serviceProviderId)
        => await Context.ServiceProviderPlan
                        .Include(c => c.Plans)
                        .AsSplitQuery()
                        .Where(c => c.ServiceProviderId == serviceProviderId)
                        .SelectMany(c => c.Plans)
                        .ToListAsync();
}