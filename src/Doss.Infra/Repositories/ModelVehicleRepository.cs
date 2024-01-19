using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class ModelVehicleRepository : RepositoryBase<ModelVehicle>, IModelVehicleRepository
{
    public ModelVehicleRepository(DossDbContext context)
        : base(context) { }

    public async Task<IEnumerable<ModelVehicle>> ReturnByBrandVehicles(Guid brandVehicleId)
        => await Context.ModelVehicle.Where(c => c.BrandVehicleId == brandVehicleId).ToListAsync();
}