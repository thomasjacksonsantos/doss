using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Doss.Core.Domain.Enums;

namespace Doss.Infra.Repositories;

public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
{
    public VehicleRepository(DossDbContext context)
        : base(context)
    {

    }

    public override async Task<Vehicle> ReturnByIdAsync(Guid id)
        => await Context.Vehicle.SingleAsync(c => c.Id == id);


    public async Task UpdateDefaultVehicle(Guid serviceProviderId, Guid vehicleId, bool defaultVehicle)
    {
        var sql = @"UPDATE Vehicle set DefaultVehicle = 0
                    FROM Doss.Vehicle
                    INNER JOIN Doss.ServiceProviderVehicle on ServiceProviderVehicle.VehicleId = Vehicle.Id
                    WHERE
                        ServiceProviderVehicle.ServiceProviderId = @ServiceProviderId

                    UPDATE Doss.Vehicle SET DefaultVehicle = @DefaultVehicle
                    WHERE
                        Id = @VehicleId";

        await Connection.ExecuteAsync(sql, param: new { ServiceProviderId = serviceProviderId, VehicleId = vehicleId, DefaultVehicle = defaultVehicle });
    }

    public async Task UpdateStatusVehicle(Guid vehicleId, VehicleStatus vehicleStatus)
    {
        var sql = @"UPDATE Doss.Vehicle SET VehicleStatus = @VehicleStatus
                    WHERE
                        Id = @VehicleId";

        await Connection.ExecuteAsync(sql, param: new { VehicleId = vehicleId, VehicleStatus = vehicleStatus.ToString() });
    }

    public async Task<Vehicle> ReturnVehicleById(Guid vehicleId)
        => await Context.Vehicle
                    .FirstOrDefaultAsync(c => c.Id == vehicleId)
                     ?? null!;

    public async Task KeepDefaultVehicleUpdate(Guid serviceProviderId, Guid vehicleId)
        => await Connection.ExecuteAsync(@" update v set v.DefaultVehicle = 0 from Doss.ServiceProvider sp
                                            inner join Doss.ServiceProviderVehicle spv on sp.Id = spv.ServiceProviderId
                                            inner join Doss.Vehicle v on spv.VehicleId = v.Id
                                            WHERE
                                                sp.Id = @ServiceProviderId
                                                AND 
                                                    v.Id <> @VehicleId",
                                        param: new { ServiceProviderId = serviceProviderId, VehicleId = vehicleId },
                                        commandType: System.Data.CommandType.Text);
}