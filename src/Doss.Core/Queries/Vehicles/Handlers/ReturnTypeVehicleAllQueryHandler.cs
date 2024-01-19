using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnTypeVehicleAllQueryHandler : IRequestHandler<ReturnTypeVehicleAllQuery, Result<ReturnTypeVehicleAllQuery.Response>>
{
    private readonly ITypeVehicleRepository typeVehicleRepository;

    public ReturnTypeVehicleAllQueryHandler(ITypeVehicleRepository typeVehicleRepository)
        => this.typeVehicleRepository = typeVehicleRepository;

    public async Task<Result<ReturnTypeVehicleAllQuery.Response>> Handle(ReturnTypeVehicleAllQuery query, CancellationToken cancellationToken)
    {
        var typeVehicles = await typeVehicleRepository.ReturnAllAsync();
        return Results.Ok(new ReturnTypeVehicleAllQuery.Response(typeVehicles.Select(c => new ReturnTypeVehicleAllQuery.TypeVehicle(c.Id, c.Description))));
    }
}