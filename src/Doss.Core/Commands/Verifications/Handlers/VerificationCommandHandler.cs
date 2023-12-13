using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Verifications.Handlers;

public class VerificationCommandHandler : BaseCommandHandler<VerificationCommand, VerificationCommandValidator>
{
    private readonly IVerificationRepository verificationRepository;
    public VerificationCommandHandler(IVerificationRepository verificationRepository,
                                      VerificationCommandValidator validator)
        : base(validator)
            => this.verificationRepository = verificationRepository;

    public override async Task<Result> HandleImplementation(VerificationCommand command)
    {
        await verificationRepository.AddAsync(new Domain.Verifications.Verification(command.ServiceProviderId, command.ResidentialId, command.Message));
        await verificationRepository.SaveAsync();

        return Results.Ok("Vehicle created with success.");
    }
}

public sealed class VerificationCommandValidator : AbstractValidator<VerificationCommand>
{
    public VerificationCommandValidator()
    {
    }
}