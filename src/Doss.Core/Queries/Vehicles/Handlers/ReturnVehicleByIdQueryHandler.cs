using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehicleByIdQueryHandler : IRequestHandler<ReturnVehicleByIdQuery, Result<ReturnVehicleByIdQuery.Response>>
{
    private readonly IVehicleRepository vehicleRepository;

    public ReturnVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
        => this.vehicleRepository = vehicleRepository;

    public async Task<Result<ReturnVehicleByIdQuery.Response>> Handle(ReturnVehicleByIdQuery query, CancellationToken cancellationToken)
    {

        var vehicle = await vehicleRepository.ReturnByIdAsync(query.Id);

        return Results.Ok(new ReturnVehicleByIdQuery.Response(new ReturnVehicleByIdQuery.Vehicle(vehicle.Id,
                                                                                                    vehicle.ModelVehicle.BrandVehicle.TypeVehicleId,
                                                                                                    vehicle.ModelVehicle.BrandVehicleId,
                                                                                                    vehicle.ModelVehicleId,
                                                                                                    vehicle.Color,
                                                                                                    vehicle.Plate,
                                                                                                    vehicle.Photo,
                                                                                                    vehicle.DefaultVehicle,
                                                                                                    vehicle.Created,
                                                                                                    vehicle.Updated)));
    }
}