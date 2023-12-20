using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.ServicesProviders.Handlers;

public class UpdatePlanCommandHandler : BaseCommandHandler<UpdatePlanCommand, UpdatePlanCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    public UpdatePlanCommandHandler(IServiceProviderRepository serviceProviderRepository, UpdatePlanCommandValidator validator)
        : base(validator)
            => this.serviceProviderRepository = serviceProviderRepository;

    public override async Task<Result> HandleImplementation(UpdatePlanCommand command)
    {
        // var plan = await serviceProviderRepository.ReturnPlan(command.User.Id, command.Id);
        
        // plan.ChangePlanStatus(command.PlanStatus);
        // plan.ChangePlanAccountBank(command.PlanAccountBank.BankId, command.PlanAccountBank.Agency, command.PlanAccountBank.Account);

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Plan updated with success.");
    }
}

public sealed class UpdatePlanCommandValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PlanAccountBank.Account).NotEmpty();
        RuleFor(c => c.PlanAccountBank.Agency).NotEmpty();
        RuleFor(c => c.PlanAccountBank.BankId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();  
    }
}