using Doss.Core.Commands.OnBoard.Residentials;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.Residentials.Handlers;

public class ResidentialOnBoardUserInformationCommandHandler : BaseCommandHandler<ResidentialOnBoardUserInformationCommand, ResidentialOnBoardUserInformationCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;

    public ResidentialOnBoardUserInformationCommandHandler(IOnBoardResidentialRepository onBoardResidentialRepository,
                                                           ResidentialOnBoardUserInformationCommandValidator validator)
        : base(validator)
            => this.onBoardResidentialRepository = onBoardResidentialRepository;

    public override async Task<Result> HandleImplementation(ResidentialOnBoardUserInformationCommand command)
    {
        var residentialOnBoard = await onBoardResidentialRepository.ReturnByIdAsync(command.User!.Id);

        if (residentialOnBoard.IsNull())
        {
            residentialOnBoard = new OnBoardResidential(OnBoardStepEnum.UserInfo);

            residentialOnBoard.AddUser(command.User.Id, new OnBoardUser(command.Name,
                                                                        command.Document,
                                                                        command.Phone,
                                                                        command.Photo));

            await onBoardResidentialRepository.AddAsync(residentialOnBoard);
        }
        else
        {
            residentialOnBoard.User.ChangeName(command.Name);
            residentialOnBoard.User.ChangeDocument(command.Document);
            residentialOnBoard.User.ChangePhone(command.Phone);
            residentialOnBoard.User.ChangePhoto(command.Photo);
        }

        await onBoardResidentialRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ResidentialOnBoardUserInformationCommandValidator : AbstractValidator<ResidentialOnBoardUserInformationCommand>
{
    public ResidentialOnBoardUserInformationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Document).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}