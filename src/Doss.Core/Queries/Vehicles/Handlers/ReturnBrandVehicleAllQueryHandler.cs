using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnBrandVehicleAllQueryHandler : IRequestHandler<ReturnBrandVehicleAllQuery, Result<ReturnBrandVehicleAllQuery.Response>>
{
    private readonly IBrandVehicleRepository brandVehicleRepository;

    public ReturnBrandVehicleAllQueryHandler(IBrandVehicleRepository brandVehicleRepository)
        => this.brandVehicleRepository = brandVehicleRepository;

    public async Task<Result<ReturnBrandVehicleAllQuery.Response>> Handle(ReturnBrandVehicleAllQuery query, CancellationToken cancellationToken)
    {
        var typeVehicles = await brandVehicleRepository.ReturnByTypeVehicles(query.TypeVehicleId);
        return Results.Ok(new ReturnBrandVehicleAllQuery.Response(typeVehicles.Select(c => new ReturnBrandVehicleAllQuery.BrandVehicle(c.Id, c.Description))));
    }
}