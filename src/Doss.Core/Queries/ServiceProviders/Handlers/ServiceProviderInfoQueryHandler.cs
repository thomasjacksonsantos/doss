using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ServiceProviderInfoQueryHandler : IRequestHandler<ServiceProviderInfoQuery, Result<ServiceProviderInfoQuery.Response>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly AppSettings appSettings;

    public ServiceProviderInfoQueryHandler(IServiceProviderRepository serviceProviderRepository,
                                           AppSettings appSettings)
        => (this.serviceProviderRepository, this.appSettings) = (serviceProviderRepository, appSettings);

    public async Task<Result<ServiceProviderInfoQuery.Response>> Handle(ServiceProviderInfoQuery query, CancellationToken cancellationToken)
    {
        var response = await serviceProviderRepository
                        .SqlSingleAsync<ServiceProviderInfoQuery.Response>("SELECT Name, UserStatus, PhotoUrl from Doss.ServiceProvider WHERE Id = @UserId",
                        new { UserId = query.User!.Id });

        response.AddPhotoUrl($"{appSettings.Files.DownloadImageUrl}/{response.PhotoUrl}");

        return Results.Ok(response);
    }

}