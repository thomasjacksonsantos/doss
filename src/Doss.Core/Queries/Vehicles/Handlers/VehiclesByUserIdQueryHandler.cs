using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class VehicleByIdQueryHandler : IRequestHandler<VehicleByUserIdQuery, Result<VehicleByUserIdQuery.Response>>
{
    private readonly IVehicleRepository vehicleRepository;

    public VehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
        => this.vehicleRepository = vehicleRepository;

    public async Task<Result<VehicleByUserIdQuery.Response>> Handle(VehicleByUserIdQuery query, CancellationToken cancellationToken)
    {
        var sql = @"Select 
                    Vehicle.Id,
                    Vehicle.Brand,
                    Vehicle.Model,
                    Vehicle.Color,
                    Vehicle.Plante,
                    Vehicle.DefaultVehicle,
                    Vehicle.VehicleType,
                    Vehicle.Created
                      from Vehicle
                        Inner Join UserVehicle On Vehicle.Id = UserVehicle.VehicleId
                        Where UserVehicle.UserId = @UserId 
                        Order By Vehicle.DefaultVehicle";
        var vehicles = await vehicleRepository.SqlListAsync(sql, new { UserId = query.User!.Id });

        return Results.Ok(new VehicleByUserIdQuery.Response(vehicles
                                                            .Select(c => 
                                                                new VehicleByUserIdQuery.Vehicle(c.Id, 
                                                                                                 c.Brand, 
                                                                                                 c.Model, 
                                                                                                 c.Color, 
                                                                                                 c.Plate, 
                                                                                                 c.Photo, 
                                                                                                 c.DefaultVehicle, 
                                                                                                 c.VehicleType, 
                                                                                                 c.Created))));
    }
}