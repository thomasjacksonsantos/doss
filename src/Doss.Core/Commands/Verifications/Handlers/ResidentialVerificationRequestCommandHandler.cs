using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Verifications.Handlers;

public class ResidentialVerificationRequestCommandHandler : BaseCommandHandler<ResidentialVerificationRequestCommand, ResidentialVerificationRequestCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    public ResidentialVerificationRequestCommandHandler(IResidentialRepository residentialRepository,
                                                        ResidentialVerificationRequestCommandValidator validator)
        : base(validator)
            => this.residentialRepository = residentialRepository;

    public override async Task<Result> HandleImplementation(ResidentialVerificationRequestCommand command)
    {
        var residentialWithServiceProvider = await residentialRepository.ReturnResidentialWithServiceProvider(command.ResidentialWithServiceProviderId);
        await residentialRepository.AddVerificationRequest(new Domain.Residentials.ResidentialVerificationRequest(residentialWithServiceProvider, command.Message), saveChanges: true);

        return Results.Ok("Verification created with success.");
    }
}

public sealed class ResidentialVerificationRequestCommandValidator : AbstractValidator<ResidentialVerificationRequestCommand>
{
    public ResidentialVerificationRequestCommandValidator()
    {
        RuleFor(c => c.ResidentialWithServiceProviderId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}