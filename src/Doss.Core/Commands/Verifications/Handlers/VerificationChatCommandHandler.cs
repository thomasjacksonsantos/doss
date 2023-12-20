using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Verifications.Handlers;

public class VerificationChatCommandHandler : BaseCommandHandler<VerificationChatCommand, VerificationChatCommandValidator>
{
    private readonly IUnitOfWork unitOfWork;
    public VerificationChatCommandHandler(IUnitOfWork unitOfWork,
                                          VerificationChatCommandValidator validator)
        : base(validator)
            => (this.unitOfWork) = (unitOfWork);

    public override async Task<Result> HandleImplementation(VerificationChatCommand command)
    {
        if (command.Message.IsNull() && command.Photo.IsNull() && command.Audio.IsNull())
            return Results.Error("Message is empty");

        var verification = await unitOfWork.ResidencialRepository.ReturnVerificationRequestById(command.ResidentialVerificationRequestId);
        verification.AddMessage(command.User!.Id, command.Message, command.Photo);
        await unitOfWork.ServiceProviderRepository.SaveAsync();
        
        return Results.Ok("Message created with success.");
    }
}

public sealed class VerificationChatCommandValidator : AbstractValidator<VerificationChatCommand>
{
    public VerificationChatCommandValidator()
    {
        RuleFor(c => c.ResidentialVerificationRequestId).NotEmpty();
    }
}