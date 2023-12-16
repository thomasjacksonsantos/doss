using System.Data;
using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class CreateVerificationMessageCommandHandler : BaseCommandHandler<CreateVerificationMessageCommand, CreateVerificationMessageCommandValidator>
{
    private readonly IUnitOfWork unitOfWork;
    public CreateVerificationMessageCommandHandler(IUnitOfWork unitOfWork,
                                                    CreateVerificationMessageCommandValidator validator)
        : base(validator)
            => (this.unitOfWork) = (unitOfWork);

    public override async Task<Result> HandleImplementation(CreateVerificationMessageCommand command)
    {
        var verification = await unitOfWork.ResidencialRepository.ReturnVerificationRequestById(command.ResidentialVerificationRequestId);
        verification.AddMessage(command.User!.Id, command.Message, command.Photo);
        await unitOfWork.ServiceProviderRepository.SaveAsync();
        
        return Results.Ok("Message created with success.");
    }
}

public sealed class CreateVerificationMessageCommandValidator : AbstractValidator<CreateVerificationMessageCommand>
{
    public CreateVerificationMessageCommandValidator()
    {
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.ResidentialVerificationRequestId).NotEmpty();
    }
}