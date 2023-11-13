using Doss.Core.Domain.Plans;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ReturnServiceProviderPlanByIdQueryHandler : IRequestHandler<ReturnServiceProviderPlanByIdQuery, Result<IEnumerable<Plan>>>
{
    private readonly IServiceProviderRepository guardRepository;

    public ReturnServiceProviderPlanByIdQueryHandler(IServiceProviderRepository guardRepository)
        => this.guardRepository = guardRepository;

    public async Task<Result<IEnumerable<Plan>>> Handle(ReturnServiceProviderPlanByIdQuery query, CancellationToken cancellationToken)
        => Results.Ok(await guardRepository.ReturnPlanAll(query.Id));    
}