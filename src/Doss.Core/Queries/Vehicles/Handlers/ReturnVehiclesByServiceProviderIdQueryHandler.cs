using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehiclesByServiceProviderIdQueryHandler : IRequestHandler<ReturnVehiclesByServiceProviderIdQuery, Result<ReturnVehiclesByServiceProviderIdQuery.Response>>
{
    private readonly IServiceProviderVehicleRepository serviceProviderVehicleRepository;

    public ReturnVehiclesByServiceProviderIdQueryHandler(IServiceProviderVehicleRepository serviceProviderVehicleRepository)
        => this.serviceProviderVehicleRepository = serviceProviderVehicleRepository;

    public async Task<Result<ReturnVehiclesByServiceProviderIdQuery.Response>> Handle(ReturnVehiclesByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {

        var vehicles = await serviceProviderVehicleRepository.ReturnAllAsync(c => c.ServiceProviderId == query.User!.Id, includeProperties: "Vehicle");

        return Results.Ok(new ReturnVehiclesByServiceProviderIdQuery.Response(vehicles
                                                            .Select(c =>
                                                                new ReturnVehiclesByServiceProviderIdQuery.Vehicle(c.Vehicle.Id,
                                                                                                                    c.Vehicle.Brand,
                                                                                                                    c.Vehicle.Model,
                                                                                                                    c.Vehicle.Color,
                                                                                                                    c.Vehicle.Plate,
                                                                                                                    c.Vehicle.Photo,
                                                                                                                    c.Vehicle.DefaultVehicle,
                                                                                                                    c.Vehicle.VehicleType,
                                                                                                                    c.Vehicle.Created,
                                                                                                                    c.Vehicle.Updated))));
    }
}