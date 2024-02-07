using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ResidentialDetailsyServiceProviderIdQueryHandler : IRequestHandler<ResidentialDetailsByServiceProviderIdQuery, Result<ResidentialDetailsByServiceProviderIdQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialDetailsyServiceProviderIdQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialDetailsByServiceProviderIdQuery.Response>> Handle(ResidentialDetailsByServiceProviderIdQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.ReturnResidentialDetails(query.ResidentialId, query.User!.Id));
}