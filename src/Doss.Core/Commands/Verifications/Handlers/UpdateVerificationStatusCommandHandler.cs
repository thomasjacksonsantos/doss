using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Verifications.Handlers;

public class UpdateVerificationStatusCommandHandler : BaseCommandHandler<UpdateVerificationStatusCommand, UpdateVerificationStatusValidator>
{
    private readonly IVerificationRepository verificationRepository;
    public UpdateVerificationStatusCommandHandler(IVerificationRepository verificationRepository,
                                                  UpdateVerificationStatusValidator validator)
        : base(validator)
            => this.verificationRepository = verificationRepository;

    public override async Task<Result> HandleImplementation(UpdateVerificationStatusCommand command)
    {
        await verificationRepository.ExecuteAsync(sql: "UPDATE Doss.Verification SET [Status] = @Status WHERE Id = @Id ", param: new { command.Id, command.Status });
        return Results.Ok("Verification created with success.");
    }
}

public sealed class UpdateVerificationStatusValidator : AbstractValidator<UpdateVerificationStatusCommand>
{
    public UpdateVerificationStatusValidator()
    {
    }
}