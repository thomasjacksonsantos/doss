using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Doss.Infra.Repositories;

public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
{
    public VehicleRepository(DossDbContext context)
        : base(context)
    {

    }

    public override async Task<Vehicle> ReturnByIdAsync(Guid id)
        => await Context.Vehicle.SingleAsync(c => c.Id == id);
}