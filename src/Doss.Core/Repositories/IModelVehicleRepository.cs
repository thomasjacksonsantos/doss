
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Interfaces.Repositories;

public interface IModelVehicleRepository : IRepositoryBase<ModelVehicle>
{
    Task<IEnumerable<ModelVehicle>> ReturnByBrandVehicles(Guid brandVehicleId);
}