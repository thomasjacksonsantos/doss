using Doss.Core.Commands.Verifications;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Verifications.Handlers;

public class UpdateServiceProviderVerificationStatusCommandHandler : BaseCommandHandler<UpdateServiceProviderVerificationStatusCommand, UpdateServiceProviderVerificationStatusCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    public UpdateServiceProviderVerificationStatusCommandHandler(IResidentialRepository residentialRepository,
                                                                 UpdateServiceProviderVerificationStatusCommandValidator validator)
        : base(validator)
            => (this.residentialRepository) = (residentialRepository);

    public override async Task<Result> HandleImplementation(UpdateServiceProviderVerificationStatusCommand command)
    {
        await residentialRepository.UpdateVerificationStatus(command.VerificationId, command.Status);

        return Results.Ok("Status updated with success.");
    }
}

public sealed class UpdateServiceProviderVerificationStatusCommandValidator : AbstractValidator<UpdateServiceProviderVerificationStatusCommand>
{
    public UpdateServiceProviderVerificationStatusCommandValidator()
    {
        RuleFor(c => c.VerificationId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}