using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;

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
        var messages = await residentialRepository.ReturnChatMessage(query.ResidentialVerificationRequestId, query.Page, query.Total);

        messages.ForEach(c => c.AddUrlBase(appSettings.Images.DownloadImageUrl));
        return Results.Ok(new ReturnChatQuery.Response(messages));
    }
}