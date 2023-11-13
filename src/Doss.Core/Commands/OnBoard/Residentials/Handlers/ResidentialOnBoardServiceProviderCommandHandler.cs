using Doss.Core.Commands.OnBoard.Residentials;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.Residentials.Handlers;

public class ResidentialOnBoardServiceProviderCommandHandler : BaseCommandHandler<ResidentialOnBoardServiceProviderCommand, ResidentialOnBoardServiceProviderCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;

    public ResidentialOnBoardServiceProviderCommandHandler(IOnBoardResidentialRepository onBoardResidentialRepository,
                                                            IServiceProviderRepository serviceProviderRepository,
                                                            ResidentialOnBoardServiceProviderCommandValidator validator)
        : base(validator)
            => (this.onBoardResidentialRepository, this.serviceProviderRepository) = (onBoardResidentialRepository, serviceProviderRepository);

    public override async Task<Result> HandleImplementation(ResidentialOnBoardServiceProviderCommand command)
    {
        var residentialOnBoard = await onBoardResidentialRepository.ReturnByIdAsync(command.User!.Id);
        if (residentialOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.ServiceProviderId);

        residentialOnBoard.ChangeStep(OnBoardStepEnum.Address);
        residentialOnBoard.AddServiceProvider(serviceProvider);
        residentialOnBoard.AddPlan(serviceProvider.ReturnPlanById(command.PlanId)!);
        await onBoardResidentialRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ResidentialOnBoardServiceProviderCommandValidator : AbstractValidator<ResidentialOnBoardServiceProviderCommand>
{
    public ResidentialOnBoardServiceProviderCommandValidator()
    {
        RuleFor(c => c.PlanId).NotEmpty();
        RuleFor(c => c.ServiceProviderId).NotEmpty();
    }
}