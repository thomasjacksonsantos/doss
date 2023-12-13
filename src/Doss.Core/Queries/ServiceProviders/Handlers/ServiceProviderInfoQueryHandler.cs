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
    {
        var sql = @"SELECT Name, UserStatus, Photo from Doss.ServiceProvider
                    WHERE
                        Id = @UserId";

        return Results.Ok(await serviceProviderRepository
                                .SqlSingleAsync<ServiceProviderInfoQuery.Response>(sql, new { UserId = query.User.Id }));
    }
}