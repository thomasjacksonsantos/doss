using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehiclesByResidentialIdQueryHandler : IRequestHandler<ReturnVehiclesByResidentialIdQuery, Result<ReturnVehiclesByResidentialIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ReturnVehiclesByResidentialIdQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ReturnVehiclesByResidentialIdQuery.Response>> Handle(ReturnVehiclesByResidentialIdQuery query, CancellationToken cancellationToken)
    {

        var residential = await residentialRepository.ReturnVehicles(query.User!.Id, query.ResidentialWithServiceProviderId);
        var residentialWithServiceProvider = residential.ReturnResidentialWithServiceProvider(query.ResidentialWithServiceProviderId);

        return Results.Ok(new ReturnVehiclesByResidentialIdQuery.Response(residentialWithServiceProvider.ResidentialVehicles!
                                                            .Select(c =>
                                                                new ReturnVehiclesByResidentialIdQuery.Vehicle(c.Vehicle.Id,
                                                                                                                    c.Vehicle.ModelVehicle.BrandVehicle.TypeVehicleId,
                                                                                                                    c.Vehicle.ModelVehicle.BrandVehicleId,
                                                                                                                    c.Vehicle.ModelVehicleId,
                                                                                                                    c.Vehicle.Color,
                                                                                                                    c.Vehicle.Plate,
                                                                                                                    c.Vehicle.Photo,
                                                                                                                    c.Vehicle.DefaultVehicle,
                                                                                                                    c.Vehicle.Created,
                                                                                                                    c.Vehicle.Updated))));
    }
}