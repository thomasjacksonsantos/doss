using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ReturnServiceProvidersByZipCodeQueryHandler : IRequestHandler<ReturnServiceProvidersByZipCodeQuery, Result<IEnumerable<ServiceProvider>>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ReturnServiceProvidersByZipCodeQueryHandler(IServiceProviderRepository serviceProviderRepository)
        => this.serviceProviderRepository = serviceProviderRepository;

    public async Task<Result<IEnumerable<ServiceProvider>>> Handle(ReturnServiceProvidersByZipCodeQuery query, CancellationToken cancellationToken)
    {
        var serviceProviders = await serviceProviderRepository.ReturnByZipCodeAsync(query.ZipCode);

        if (serviceProviders is not { })
            return Results.Error<IEnumerable<ServiceProvider>>("Service providers not found.");

        return Results.Ok(serviceProviders);
    }
}