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

        var vehicles = await serviceProviderVehicleRepository.ReturnAllVehicles(query.User!.Id, query.Page, query.Total);

        return Results.Ok(new ReturnVehiclesByServiceProviderIdQuery.Response(vehicles
                                                            .Select(c =>
                                                                new ReturnVehiclesByServiceProviderIdQuery.Vehicle(c.Id,
                                                                                                                    c.Brand,
                                                                                                                    c.Model,
                                                                                                                    c.Color,
                                                                                                                    c.Plate,
                                                                                                                    c.Photo,
                                                                                                                    c.DefaultVehicle,
                                                                                                                    c.VehicleType,
                                                                                                                    c.VehicleStatus,
                                                                                                                    c.Created,
                                                                                                                    c.Updated))));
    }
}