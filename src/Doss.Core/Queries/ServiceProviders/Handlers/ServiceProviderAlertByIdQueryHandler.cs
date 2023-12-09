using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ServiceProviderAlertByIdQueryHandler : IRequestHandler<ServiceProviderAlertByIdQuery, Result<ServiceProviderAlertByIdQuery.Response>>
{
    private readonly IServiceProviderAlertRepository serviceProviderAlertRepository;

    public ServiceProviderAlertByIdQueryHandler(IServiceProviderAlertRepository serviceProviderAlertRepository)
        => this.serviceProviderAlertRepository = serviceProviderAlertRepository;

    public async Task<Result<ServiceProviderAlertByIdQuery.Response>> Handle(ServiceProviderAlertByIdQuery query, CancellationToken cancellationToken)
    {
        var sql = @"Select Description, Created
                    from Doss.ServiceProviderAlert 
                    Order By Created Desc
                    OFFSET (@Page - 1) * @PageSize ROWS
                    FETCH NEXT @PageSize ROWS ONLY ";
        var alertMessage = await serviceProviderAlertRepository.SqlListAsync(sql, new { Page = query.Page == 0 ? 1 : query.Page, PageSize = 10 });

        return Results.Ok(new ServiceProviderAlertByIdQuery.Response(alertMessage
                                                        .Select(c => new ServiceProviderAlertByIdQuery.Message(c.Description, c.Created))
                                                        .ToList()));
    }
}