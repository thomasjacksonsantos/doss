using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;

namespace Doss.Infra.Repositories;

public class TypeVehicleRepository : RepositoryBase<TypeVehicle>, ITypeVehicleRepository
{
    public TypeVehicleRepository(DossDbContext context)
        : base(context) { }
}