using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ServiceProviderCheckQueryHandler : IRequestHandler<ServiceProviderCheckQuery, Result<ServiceProviderCheckQuery.Response>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ServiceProviderCheckQueryHandler(IServiceProviderRepository serviceProviderRepository)
        => this.serviceProviderRepository = serviceProviderRepository;

    public async Task<Result<ServiceProviderCheckQuery.Response>> Handle(ServiceProviderCheckQuery query, CancellationToken cancellationToken)
        => Results.Ok(await serviceProviderRepository.SqlSingleAsync<ServiceProviderCheckQuery.Response>("SELECT Id from Doss.ServiceProvider WHERE Id = @UserId",
                                                                                                            new { UserId = query.User!.Id }));
}