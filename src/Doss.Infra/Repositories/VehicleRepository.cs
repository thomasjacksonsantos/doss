using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;

namespace Doss.Infra.Repositories;

public class VehicleRepository : RepositoryBase<UserVehicle>, IVehicleRepository
{
    public VehicleRepository(DossDbContext context)
        : base(context)
    {

    }
}