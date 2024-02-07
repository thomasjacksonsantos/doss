using Doss.Core.Domain.Plans;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ReturnServiceProviderPlanTotalProfitQueryHandler : IRequestHandler<ReturnServiceProviderPlanTotalProfitQuery, Result<ReturnServiceProviderPlanTotalProfitQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ReturnServiceProviderPlanTotalProfitQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ReturnServiceProviderPlanTotalProfitQuery.Response>> Handle(ReturnServiceProviderPlanTotalProfitQuery query, CancellationToken cancellationToken)
        => Results.Ok(await residentialRepository.ReturnTotalProfit(query.User!.Id));    
}