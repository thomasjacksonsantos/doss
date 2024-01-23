using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Domain.Enums;

namespace Doss.Infra.Repositories;

public class ServiceProviderVehicleRepository : RepositoryBase<ServiceProviderVehicle>, IServiceProviderVehicleRepository
{
    public ServiceProviderVehicleRepository(DossDbContext context)
        : base(context)
    {

    }

    public async Task<IEnumerable<Vehicle>> ReturnVehiclesByStatus(Guid serviceProviderId, VehicleStatus vehicleStatus, int page, int total = 20)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        return await Context
                    .ServiceProviderVehicle
                    .Include(c => c.Vehicle)
                    .Where(c => c.ServiceProviderId == serviceProviderId && c.Vehicle.VehicleStatus == vehicleStatus)
                .Skip(page)
                .Take(total)
                .Select(c => c.Vehicle)
                .ToListAsync();
    }
}