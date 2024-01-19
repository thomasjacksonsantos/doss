using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnModelVehicleAllQueryHandler : IRequestHandler<ReturnModelVehicleAllQuery, Result<ReturnModelVehicleAllQuery.Response>>
{
    private readonly IModelVehicleRepository modelVehicleRepository;

    public ReturnModelVehicleAllQueryHandler(IModelVehicleRepository modelVehicleRepository)
        => this.modelVehicleRepository = modelVehicleRepository;

    public async Task<Result<ReturnModelVehicleAllQuery.Response>> Handle(ReturnModelVehicleAllQuery query, CancellationToken cancellationToken)
    {
        var typeVehicles = await modelVehicleRepository.ReturnByBrandVehicles(query.BrandVehicleId);
        return Results.Ok(new ReturnModelVehicleAllQuery.Response(typeVehicles.Select(c => new ReturnModelVehicleAllQuery.ModelVehicle(c.Id, c.Description))));
    }
}