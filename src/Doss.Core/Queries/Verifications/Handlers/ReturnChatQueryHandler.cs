using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Microsoft.Extensions.Options;
using MediatR;

namespace Doss.Core.Queries.Verifications.Handlers;

public class ReturnChatQueryHandler : IRequestHandler<ReturnChatQuery, Result<ReturnChatQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly AppSettings appSettings;

    public ReturnChatQueryHandler(IResidentialRepository residentialRepository,
                                  IOptions<AppSettings> options)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, options.Value);

    public async Task<Result<ReturnChatQuery.Response>> Handle(ReturnChatQuery query, CancellationToken cancellationToken)
    {
        var response = await residentialRepository.ReturnChatMessage(query.ResidentialVerificationRequestId, query.Page, query.Total);
        var residentialVerification = await residentialRepository.ReturnVerificationRequestById(query.ResidentialVerificationRequestId);

        var residential = await residentialRepository.ReturnResidentialInfo(residentialVerification.ResidentialWithServiceProvider.ResidentialId);

        response.ChangeResidential(new ReturnChatQuery.Residential(residential.Name, $"{appSettings.Files.DownloadImageUrl}/{residential.PhotoUrl}"));

        response.Chats.ForEach(c =>
        {
            c.AddImageUrlBase(appSettings.Files.DownloadImageUrl);
            c.AddAudioUrlBase(appSettings.Files.DownloadAudioUrl);
        });
        return Results.Ok(response);
    }
}