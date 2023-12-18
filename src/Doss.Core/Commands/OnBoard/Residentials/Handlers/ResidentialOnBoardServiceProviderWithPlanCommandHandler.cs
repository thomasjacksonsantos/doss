using Doss.Core.Commands.OnBoard.Residentials;
using Doss.Core.Commands.Residentials;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;
using MediatR;

namespace Ageu.Core.Commands.OnBoard.Residentials.Handlers;

public class ResidentialOnBoardServiceProviderWithPlanCommandHandler : BaseCommandHandler<ResidentialOnBoardServiceProviderWithPlanCommand, ResidentialOnBoardServiceProviderWithPlanCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IMediator mediator;

    public ResidentialOnBoardServiceProviderWithPlanCommandHandler(IOnBoardResidentialRepository onBoardResidentialRepository,
                                                                   IServiceProviderRepository serviceProviderRepository,
                                                                   IMediator mediator,
                                                                   ResidentialOnBoardServiceProviderWithPlanCommandValidator validator)
        : base(validator)
            => (this.onBoardResidentialRepository, this.serviceProviderRepository, this.mediator) = (onBoardResidentialRepository, serviceProviderRepository, mediator);

    public override async Task<Result> HandleImplementation(ResidentialOnBoardServiceProviderWithPlanCommand command)
    {
        var residentialOnBoard = await onBoardResidentialRepository.ReturnByIdAsync(command.User!.Id);
        if (residentialOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        var serviceProviderPlan = await serviceProviderRepository.ReturnServiceProviderPlan(command.ServiceProviderPlanId);

        residentialOnBoard.ChangeStep(OnBoardStepEnum.SelectPlan);
        residentialOnBoard.AddServiceProvider(serviceProviderPlan);
        residentialOnBoard.AddPlan(serviceProviderPlan.ReturnPlanById(command.PlanId)!);

        await onBoardResidentialRepository.SaveAsync();

        await mediator.Send(new CreateResidentialAfterOnBoardCompletedCommand(command.User!.Id));

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ResidentialOnBoardServiceProviderWithPlanCommandValidator : AbstractValidator<ResidentialOnBoardServiceProviderWithPlanCommand>
{
    public ResidentialOnBoardServiceProviderWithPlanCommandValidator()
    {
        RuleFor(c => c.PlanId).NotEmpty();
        RuleFor(c => c.ServiceProviderPlanId).NotEmpty();
    }
}