using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.OnBoard.Residentials.Handlers;

public class ResidentialOnBoardTermsAcceptCommandHandler : BaseCommandHandler<ResidentialOnBoardTermsAcceptCommand, ResidentialOnBoardTermsAcceptCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;

    public ResidentialOnBoardTermsAcceptCommandHandler(IOnBoardResidentialRepository onBoardResidentialRepository,
                                                           ResidentialOnBoardTermsAcceptCommandValidator validator)
        : base(validator)
            => this.onBoardResidentialRepository = onBoardResidentialRepository;

    public override async Task<Result> HandleImplementation(ResidentialOnBoardTermsAcceptCommand command)
    {
        var residentialOnBoard = await onBoardResidentialRepository.ReturnByIdAsync(command.User!.Id);
        if (residentialOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        residentialOnBoard.ChangeStep(OnBoardStepEnum.TermsAccept);

        residentialOnBoard.ChangeTermsAccept(new OnBoardTermsAccept(command.TermsAccept, DateTime.Now));

        await onBoardResidentialRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ResidentialOnBoardTermsAcceptCommandValidator : AbstractValidator<ResidentialOnBoardTermsAcceptCommand>
{
    public ResidentialOnBoardTermsAcceptCommandValidator()
        => RuleFor(c => c.TermsAccept).NotEmpty();
}