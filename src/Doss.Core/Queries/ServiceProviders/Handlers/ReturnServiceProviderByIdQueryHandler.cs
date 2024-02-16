using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProviders.Handlers;

public class ReturnServiceProviderByIdQueryHandler : IRequestHandler<ReturnServiceProviderById, Result<ReturnServiceProviderById.Response>>
{
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ReturnServiceProviderByIdQueryHandler(IServiceProviderRepository serviceProviderRepository)
        => this.serviceProviderRepository = serviceProviderRepository;

    public async Task<Result<ReturnServiceProviderById.Response>> Handle(ReturnServiceProviderById query, CancellationToken cancellationToken)
    {
        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(query.User!.Id);
        var serviceProviderPlan = serviceProvider.ServiceProviderPlans.First();
        if (serviceProvider.IsNull())
            return Results.Error<ReturnServiceProviderById.Response>("Service provider not found.");

        var response = new ReturnServiceProviderById.Response(
            new ReturnServiceProviderById.Response.ServiceProviderCommand(serviceProvider.Id, serviceProvider.Name, serviceProvider.TypeDocument, serviceProvider.Document, serviceProvider.Phone, serviceProvider.Phone),
            new ReturnServiceProviderById.Response.AddressCommand(serviceProviderPlan.Address.ZipCode,
                                                                  serviceProviderPlan.Address.Country,
                                                                  serviceProviderPlan.Address.State,
                                                                  serviceProviderPlan.Address.City,
                                                                  serviceProviderPlan.Address.Neighborhood,
                                                                  serviceProviderPlan.Address.Street,
                                                                  serviceProviderPlan.Address.Complement,
                                                                  serviceProviderPlan.Address.Number),
            new ReturnServiceProviderById.Response.CoverageCommand(serviceProviderPlan.CoverageArea),
            new ReturnServiceProviderById.Response.FormPaymentCommand(serviceProviderPlan.BankId,
                                                                      serviceProviderPlan.AgencyBank,
                                                                      serviceProviderPlan.AccountBank,
                                                                      serviceProviderPlan
                                                                        .Plans
                                                                        .Select(c => new ReturnServiceProviderById.Response.PlanCommand(c.Id, c.Description, c.Price)))
        );

        return Results.Ok(response);
    }
}