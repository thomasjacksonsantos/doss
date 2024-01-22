using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class ServiceProviderVehicleRepository : RepositoryBase<ServiceProviderVehicle>, IServiceProviderVehicleRepository
{
    public ServiceProviderVehicleRepository(DossDbContext context)
        : base(context)
    {

    }

    public async Task<IEnumerable<Vehicle>> ReturnAllVehicles(Guid serviceProviderId, int page, int total = 20)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        return await Context
                    .ServiceProviderVehicle
                    .Include(c => c.Vehicle)
                    .Where(c => c.ServiceProviderId == serviceProviderId)
                .Skip(page)
                .Take(total)
                .Select(c => c.Vehicle)
                .ToListAsync();
    }
}