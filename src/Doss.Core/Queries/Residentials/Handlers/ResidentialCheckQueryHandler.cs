using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Residentials.Handlers;

public class ResidentialCheckQueryHandler : IRequestHandler<ResidentialCheckQuery, Result<ResidentialCheckQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialCheckQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialCheckQuery.Response>> Handle(ResidentialCheckQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.SqlSingleAsync<ResidentialCheckQuery.Response>("SELECT Id from Doss.Residential WHERE Id = @UserId", new { UserId = query.User!.Id }));
}