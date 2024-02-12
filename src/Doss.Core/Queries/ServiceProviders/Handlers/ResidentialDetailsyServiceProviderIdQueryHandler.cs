using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ResidentialDetailsyServiceProviderIdQueryHandler : IRequestHandler<ResidentialDetailsByServiceProviderIdQuery, Result<ResidentialDetailsByServiceProviderIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly AppSettings appSettings;

    public ResidentialDetailsyServiceProviderIdQueryHandler(IOptions<AppSettings> appSettings, IResidentialRepository residentialRepository)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, appSettings.Value);

    public async Task<Result<ResidentialDetailsByServiceProviderIdQuery.Response>> Handle(ResidentialDetailsByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {
        var residential = await residentialRepository.ReturnResidentialDetails(query.ResidentialId, query.User!.Id);
        residential.Vehicle.ChangePhotoUrl($"{appSettings.Files.DownloadImageUrl}/{residential.Vehicle.PhotoUrl}");
        return Results.Ok(residential);
    }
}