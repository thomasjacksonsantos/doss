using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;

namespace Doss.Infra.Repositories;

public class ResidentialVehicleRepository : RepositoryBase<ResidentialVehicle>, IResidentialVehicleRepository
{
    public ResidentialVehicleRepository(DossDbContext context)
        : base(context)
    {

    }
}