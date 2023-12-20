using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.ServiceProviders.Handlers;

public class ServiceProviderPlanCommandHandler : BaseCommandHandler<ServiceProviderPlanCommand, ServiceProviderPlanCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    public ServiceProviderPlanCommandHandler(IServiceProviderRepository serviceProviderRepository, ServiceProviderPlanCommandValidator validator)
        : base(validator)
            => this.serviceProviderRepository = serviceProviderRepository;

    public override async Task<Result> HandleImplementation(ServiceProviderPlanCommand command)
    {
        // await guardRepository.AddAsync(new UserPlan(command.User.Id,
        //                                 new Plan(new PlanAccountBank(command.PlanAccountBank.BankId,
        //                                                              command.PlanAccountBank.Agency,
        //                                                              command.PlanAccountBank.Account),
        //                                                              command.Price)));

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Plan created with success.");
    }
}

public sealed class ServiceProviderPlanCommandValidator : AbstractValidator<ServiceProviderPlanCommand>
{
    public ServiceProviderPlanCommandValidator()
    {
        RuleFor(c => c.PlanAccountBank.Account).NotEmpty();
        RuleFor(c => c.PlanAccountBank.Agency).NotEmpty();
        RuleFor(c => c.PlanAccountBank.BankId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}