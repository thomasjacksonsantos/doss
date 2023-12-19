using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Verifications.Handlers;

public class ServiceProviderVerificationRequestAllQueryHandler : IRequestHandler<ServiceProviderVerificationRequestAllQuery, Result<ServiceProviderVerificationRequestAllQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ServiceProviderVerificationRequestAllQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ServiceProviderVerificationRequestAllQuery.Response>> Handle(ServiceProviderVerificationRequestAllQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.ReturnVerificationAllByServiceProvider(query.User!.Id, query.Page, query.Total));
}