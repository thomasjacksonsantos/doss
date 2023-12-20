using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Residentials.Handlers;

public class ActiveResidentialQueryHandler : IRequestHandler<ActiveResidentialQuery, Result<ActiveResidentialQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ActiveResidentialQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ActiveResidentialQuery.Response>> Handle(ActiveResidentialQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.ReturnTotalActive(query.User!.Id));
}