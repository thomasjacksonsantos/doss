
using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Interfaces.Repositories;

public interface IServiceProviderVehicleRepository : IRepositoryBase<ServiceProviderVehicle>
{
    Task<IEnumerable<Vehicle>> ReturnVehiclesByStatus(Guid serviceProviderId, VehicleStatus vehicleStatus, int page, int total = 20);
}