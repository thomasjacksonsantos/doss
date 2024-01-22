
using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Interfaces.Repositories;

public interface IVehicleRepository : IRepositoryBase<Vehicle>
{
    Task UpdateDefaultVehicle(Guid serviceProviderId, Guid vehicleId, bool defaultVehicle);

    Task UpdateStatusVehicle(Guid vehicleId, VehicleStatus vehicleStatus);
}