using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;

namespace Doss.Core.Queries.Vehicles.Handlers;

public class ReturnVehiclesByResidentialIdQueryHandler : IRequestHandler<ReturnVehiclesByResidentialIdQuery, Result<ReturnVehiclesByResidentialIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly AppSettings appSettings;

    public ReturnVehiclesByResidentialIdQueryHandler(IResidentialRepository residentialRepository,
                                                     IOptions<AppSettings> options)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, options.Value);

    public async Task<Result<ReturnVehiclesByResidentialIdQuery.Response>> Handle(ReturnVehiclesByResidentialIdQuery query, CancellationToken cancellationToken)
    {

        var residential = await residentialRepository.ReturnVehicles(query.User!.Id, query.ResidentialWithServiceProviderId);
        var residentialWithServiceProvider = residential.ReturnResidentialWithServiceProvider(query.ResidentialWithServiceProviderId);

        residentialWithServiceProvider.ResidentialVehicles!.ForEach(c => c.Vehicle.ChangePhotoUrl($"{appSettings.Files.DownloadImageUrl}/{c.Vehicle.PhotoUrl}"));

        return Results.Ok(new ReturnVehiclesByResidentialIdQuery.Response(residentialWithServiceProvider.ResidentialVehicles!
                                                            .Select(c =>
                                                                new ReturnVehiclesByResidentialIdQuery.Vehicle(c.Vehicle.Id,
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