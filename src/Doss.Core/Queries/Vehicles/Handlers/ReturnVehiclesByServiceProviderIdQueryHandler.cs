using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehiclesByServiceProviderIdQueryHandler : IRequestHandler<ReturnVehiclesByServiceProviderIdQuery, Result<ReturnVehiclesByServiceProviderIdQuery.Response>>
{
    private readonly IServiceProviderVehicleRepository serviceProviderVehicleRepository;
    private readonly AppSettings appSettings;

    public ReturnVehiclesByServiceProviderIdQueryHandler(IServiceProviderVehicleRepository serviceProviderVehicleRepository,
                                                         IOptions<AppSettings> options)
        => (this.serviceProviderVehicleRepository, this.appSettings) = (serviceProviderVehicleRepository, options.Value);

    public async Task<Result<ReturnVehiclesByServiceProviderIdQuery.Response>> Handle(ReturnVehiclesByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {
        var vehicles = await serviceProviderVehicleRepository.ReturnVehiclesByStatus(query.User!.Id, Domain.Enums.VehicleStatus.Active, query.Page, query.Total);
        
        vehicles.ForEach(c => c.ChangePhotoUrl($"{appSettings.Files.DownloadImageUrl}/{c.PhotoUrl}"));

        return Results.Ok(new ReturnVehiclesByServiceProviderIdQuery.Response(vehicles
                                                            .Select(c =>
                                                                new ReturnVehiclesByServiceProviderIdQuery.Vehicle(c.Id,
                                                                                                                    c.Brand,
                                                                                                                    c.Model,
                                                                                                                    c.Color,
                                                                                                                    c.Plate,
                                                                                                                    c.PhotoUrl,
                                                                                                                    c.DefaultVehicle,
                                                                                                                    c.VehicleType,
                                                                                                                    c.VehicleStatus,
                                                                                                                    c.Created,
                                                                                                                    c.Updated))));
    }
}