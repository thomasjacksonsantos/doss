
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Interfaces.Repositories;

public interface IServiceProviderVehicleRepository : IRepositoryBase<ServiceProviderVehicle>
{
    Task<IEnumerable<Vehicle>> ReturnAllVehicles(Guid serviceProviderId, int page, int total = 20);
}