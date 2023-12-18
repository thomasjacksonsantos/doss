using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ExistsVerificationRequestByResidentialQueryHandler : IRequestHandler<ExistsVerificationRequestByResidentialQuery, Result<ExistsVerificationRequestByResidentialQuery.Response>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ExistsVerificationRequestByResidentialQueryHandler(IServiceProviderRepository serviceProviderRepository)
        => this.serviceProviderRepository = serviceProviderRepository;

    public async Task<Result<ExistsVerificationRequestByResidentialQuery.Response>> Handle(ExistsVerificationRequestByResidentialQuery query, CancellationToken cancellationToken)
        => Results.Ok(await serviceProviderRepository
                            .SqlSingleAsync<ExistsVerificationRequestByResidentialQuery.Response>(@"SELECT COUNT(*) as Total FROM Doss.ResidentialWithServiceProvider
                                                                                                    INNER JOIN Doss.ServiceProviderPlan on ServiceProviderPlan.Id = ResidentialWithServiceProvider.ServiceProviderPlanId
                                                                                                    WHERE
                                                                                                        ServiceProviderPlan.ServiceProviderId = @UserId",
                                                                                                                                new { UserId = query.User!.Id }));

}