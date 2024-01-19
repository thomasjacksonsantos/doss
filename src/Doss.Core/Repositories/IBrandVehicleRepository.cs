
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Interfaces.Repositories;

public interface IBrandVehicleRepository : IRepositoryBase<BrandVehicle>
{
    Task<IEnumerable<BrandVehicle>> ReturnByTypeVehicles(Guid typeVehicleId);
}