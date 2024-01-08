using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;
using Doss.Core.Services;

namespace Doss.Core.Commands.Images.Handlers;

public class UploadImageCommandHandler : BaseCommandHandler<UploadImageCommand, UploadImageCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;
    public UploadImageCommandHandler(IResidentialRepository residentialRepository,
                                     IBlobStorage blobStorage,
                                     UploadImageCommandValidator validator)
        : base(validator)
            => (this.residentialRepository, this.blobStorage) = (residentialRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UploadImageCommand command)
    {
        var verificationMessage = await residentialRepository.ReturnChatMessageById(command.VerificationMessageId);
        await blobStorage.SendImage(verificationMessage.Photo, command.Filename);
        return Results.Ok("Message created with success.");
    }
}

public sealed class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
    public UploadImageCommandValidator()
    {
        RuleFor(c => c.VerificationMessageId).NotEmpty();
        RuleFor(c => c.Filename).NotEmpty();
    }
}