using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Domain.Enums;
using Dapper;
using Doss.Core.Queries.Contacts;

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

    public async Task<IEnumerable<ServiceProvider>> ReturnByZipCodeAsync(string zipCode)
        => await Context.ServiceProvider.ToListAsync();

    public async Task<ServiceProviderPlan> ReturnServiceProviderPlan(Guid id)
        => await Context.ServiceProviderPlan.Include(c => c.Plans).SingleAsync(c => c.Id == id);

    public async Task<IEnumerable<Plan>> ReturnPlanAll(Guid serviceProviderId)
        => await Context.ServiceProviderPlan
                        .Include(c => c.Plans)
                        .AsSplitQuery()
                        .Where(c => c.ServiceProviderId == serviceProviderId)
                        .SelectMany(c => c.Plans)
                        .ToListAsync();

    public async Task UpdateServiceProviderStatus(Guid id, UserStatus userStatus)
        => await Connection.ExecuteAsync(@"Update Doss.ServiceProvider set UserStatus = @UserStatus
                                            WHERE
                                                id = @Id",
                                            param: new { Id = id, UserStatus = userStatus },
                                            commandType: System.Data.CommandType.Text);

    public async Task<ServiceProvider> ReturnVehiclesAll(Guid serviceProviderId)
        => await Context.ServiceProvider
                        .Include(c => c.ServiceProviderVehicles)!
                        .ThenInclude(c => c.Vehicle)
                        .AsSplitQuery()
                        .SingleOrDefaultAsync(c => c.Id == serviceProviderId) ?? null!;    
}