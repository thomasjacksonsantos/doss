using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ResidentialListByServiceProviderIdQueryHandler : IRequestHandler<ResidentialListByServiceProviderIdQuery, Result<ResidentialListByServiceProviderIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly AppSettings appSettings;

    public ResidentialListByServiceProviderIdQueryHandler(IResidentialRepository residentialRepository,
                                                          IOptions<AppSettings> appSettings)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, appSettings.Value);

    public async Task<Result<ResidentialListByServiceProviderIdQuery.Response>> Handle(ResidentialListByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {
        var response = await residentialRepository.ReturnResidentialList(query.User!.Id, query.Page, query.Total, query.Status);

        response.Residentials.ForEach(c => c.ChangePhoto($"{appSettings.Files.DownloadImageUrl}/{c.Photo}"));

        return Results.Ok(response);
    }
}