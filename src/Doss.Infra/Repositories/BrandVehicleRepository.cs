using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class BrandVehicleRepository : RepositoryBase<BrandVehicle>, IBrandVehicleRepository
{
    public BrandVehicleRepository(DossDbContext context)
        : base(context) { }

    public async Task<IEnumerable<BrandVehicle>> ReturnByTypeVehicles(Guid typeVehicleId)
        => await Context.BrandVehicle.Where(c => c.TypeVehicleId == typeVehicleId).ToListAsync();
}