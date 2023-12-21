using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Residentials.Handlers;

public class ResidentialListByServiceProviderIdQueryHandler : IRequestHandler<ResidentialListByServiceProviderIdQuery, Result<ResidentialListByServiceProviderIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialListByServiceProviderIdQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialListByServiceProviderIdQuery.Response>> Handle(ResidentialListByServiceProviderIdQuery query, CancellationToken cancellationToken)
        => Results.Ok(new ResidentialListByServiceProviderIdQuery.Response(await residentialRepository.ReturnResidentialList(query.User!.Id,query.Page, query.Total, query.Status)));
}