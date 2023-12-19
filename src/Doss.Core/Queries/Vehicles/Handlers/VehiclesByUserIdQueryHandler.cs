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

        var vehicles = await vehicleRepository.ReturnAllAsync(c => c.UserId == query.User!.Id, includeProperties: "Vehicle");

        return Results.Ok(new VehicleByUserIdQuery.Response(vehicles
                                                            .Select(c => 
                                                                new VehicleByUserIdQuery.Vehicle(c.Id, 
                                                                                                 c.Vehicle.Brand, 
                                                                                                 c.Vehicle.Model, 
                                                                                                 c.Vehicle.Color, 
                                                                                                 c.Vehicle.Plate, 
                                                                                                 c.Vehicle.Photo, 
                                                                                                 c.Vehicle.DefaultVehicle, 
                                                                                                 c.Vehicle.VehicleType, 
                                                                                                 c.Created))));
    }
}