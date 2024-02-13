using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Microsoft.Extensions.Options;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ResidentialVehicleListByServiceProviderIdQueryHandler : IRequestHandler<ResidentialVehicleListByServiceProviderIdQuery, Result<ResidentialVehicleListByServiceProviderIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    private readonly AppSettings appSettings;

    public ResidentialVehicleListByServiceProviderIdQueryHandler(IResidentialRepository residentialRepository,
                                                                 IOptions<AppSettings> appSettings)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, appSettings.Value);

    public async Task<Result<ResidentialVehicleListByServiceProviderIdQuery.Response>> Handle(ResidentialVehicleListByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {
        var response = await residentialRepository.ReturnResidentialVehicleList(query.User!.Id, query.ResidentialId, query.Page, query.Total);

        response.Vehicles.ForEach(c => c.ChangePhotoUrl($"{appSettings.Files.DownloadImageUrl}/{c.Photo}"));

        return Results.Ok(response);
    }
}