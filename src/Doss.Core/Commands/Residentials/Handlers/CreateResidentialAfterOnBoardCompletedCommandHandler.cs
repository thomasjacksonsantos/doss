using Doss.Core.Commands.Residentials;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Residentials.Handlers;

public class CreateResidentialAfterOnBoardCompletedCommandHandler : BaseCommandHandler<CreateResidentialAfterOnBoardCompletedCommand, CreateResidentialAfterOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;
    private readonly IResidentialRepository residentialRepository;

    public CreateResidentialAfterOnBoardCompletedCommandHandler(IResidentialRepository residentialRepository,
                                                       IOnBoardResidentialRepository onBoardResidentialRepository,
                                                       CreateResidentialAfterOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.onBoardResidentialRepository, this.residentialRepository) = (onBoardResidentialRepository, residentialRepository);

    public override async Task<Result> HandleImplementation(CreateResidentialAfterOnBoardCompletedCommand command)
    {
        var onboard = await onBoardResidentialRepository.ReturnByIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var residential = await residentialRepository.ReturnByIdAsync(command.UserId);

        if (residential.IsNotNull())
            return Results.Error("residential has already been registered.");

        residential = new Doss.Core.Domain.Residentials.Residential(command.UserId, onboard.OnBoardUser.Name, onboard.OnBoardUser.TypeDocument, onboard.OnBoardUser.Document,
                                                                    onboard.OnBoardUser.Phone, onboard.OnBoardUser.Phone, true);

        residential.AddResidentialWithServiceProvider(new Doss.Core.Domain.Residentials.ResidentialWithServiceProvider(onboard.ServiceProviderPlanId!.Value, onboard.PlanId!.Value, onboard.Address!));
        await residentialRepository.AddAsync(residential, saveChanges: true);

        return Results.Ok("Residentia user created with success.");
    }
}

public sealed class CreateResidentialAfterOnBoardCompletedCommandValidator : AbstractValidator<CreateResidentialAfterOnBoardCompletedCommand>
{
    public CreateResidentialAfterOnBoardCompletedCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}