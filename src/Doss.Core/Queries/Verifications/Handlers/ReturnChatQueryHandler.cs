using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Verifications.Handlers;

public class ReturnChatQueryHandler : IRequestHandler<ReturnChatQuery, Result<ReturnChatQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ReturnChatQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ReturnChatQuery.Response>> Handle(ReturnChatQuery query, CancellationToken cancellationToken)
        => Results.Ok(new ReturnChatQuery.Response(await residentialRepository.ReturnChatMessage(query.ResidentialVerificationRequestId, query.Page, query.Total)));
}