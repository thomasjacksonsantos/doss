using Doss.Core.Domain.Users;
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
    {
        var sql = @"SELECT UserId from Doss.ServiceProvider
                    WHERE
                        UserId = @UserId";

        var serviceProviderCheck = await serviceProviderRepository.SqlSingleAsync<ServiceProviderCheckQuery.Response>(sql, new { UserId = query.User.Id });

        return Results.Ok(serviceProviderCheck);
    }
}