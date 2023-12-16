using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ServiceProviderInfoQueryHandler : IRequestHandler<ServiceProviderInfoQuery, Result<ServiceProviderInfoQuery.Response>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ServiceProviderInfoQueryHandler(IServiceProviderRepository serviceProviderRepository)
        => this.serviceProviderRepository = serviceProviderRepository;

    public async Task<Result<ServiceProviderInfoQuery.Response>> Handle(ServiceProviderInfoQuery query, CancellationToken cancellationToken)
        => Results.Ok(await serviceProviderRepository
                            .SqlSingleAsync<ServiceProviderInfoQuery.Response>("SELECT Name, UserStatus, Photo from Doss.ServiceProvider WHERE Id = @UserId",
                            new { UserId = query.User!.Id }));

}