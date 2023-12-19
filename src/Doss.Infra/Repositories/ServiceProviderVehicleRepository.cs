using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;

namespace Doss.Infra.Repositories;

public class ServiceProviderVehicleRepository : RepositoryBase<ServiceProviderVehicle>, IServiceProviderVehicleRepository
{
    public ServiceProviderVehicleRepository(DossDbContext context)
        : base(context)
    {

    }
}