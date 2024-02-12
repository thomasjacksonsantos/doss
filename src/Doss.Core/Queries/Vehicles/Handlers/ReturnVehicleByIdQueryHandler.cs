using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Domain.Settings;
using Microsoft.Extensions.Options;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehicleByIdQueryHandler : IRequestHandler<ReturnVehicleByIdQuery, Result<ReturnVehicleByIdQuery.Response>>
{
    private readonly IVehicleRepository vehicleRepository;
    private readonly AppSettings appSettings;

    public ReturnVehicleByIdQueryHandler(IVehicleRepository vehicleRepository,  IOptions<AppSettings> options)
        => (this.vehicleRepository, this.appSettings) = (vehicleRepository, options.Value);

    public async Task<Result<ReturnVehicleByIdQuery.Response>> Handle(ReturnVehicleByIdQuery query, CancellationToken cancellationToken)
    {

        var vehicle = await vehicleRepository.ReturnByIdAsync(query.Id);

        return Results.Ok(new ReturnVehicleByIdQuery.Response(new ReturnVehicleByIdQuery.Vehicle(vehicle.Id,
                                                                                                    vehicle.Brand,
                                                                                                    vehicle.Model,
                                                                                                    vehicle.Color,
                                                                                                    vehicle.Plate,
                                                                                                    vehicle.PhotoUrl,
                                                                                                    vehicle.DefaultVehicle,
                                                                                                    vehicle.VehicleType,
                                                                                                    vehicle.Created,
                                                                                                    vehicle.Updated)));
    }
}