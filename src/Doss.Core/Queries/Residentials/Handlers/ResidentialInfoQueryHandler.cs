using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Residentials.Handlers;

public class ResidentialInfoQueryHandler : IRequestHandler<ResidentialInfoQuery, Result<ResidentialInfoQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialInfoQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialInfoQuery.Response>> Handle(ResidentialInfoQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.ReturnResidentialInfo(query.User!.Id));
}