using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;
using Doss.Core.Services;

namespace Doss.Core.Commands.Files.Handlers;

public class UploadAudioCommandHandler : BaseCommandHandler<UploadAudioCommand, UploadAudioCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;
    public UploadAudioCommandHandler(IResidentialRepository residentialRepository,
                                     IBlobStorage blobStorage,
                                     UploadAudioCommandValidator validator)
        : base(validator)
            => (this.residentialRepository, this.blobStorage) = (residentialRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UploadAudioCommand command)
    {
        var verificationMessage = await residentialRepository.ReturnChatMessageById(command.VerificationMessageId);
        await blobStorage.SendAudio(verificationMessage.Audio, command.Filename);
        return Results.Ok("Message created with success.");
    }
}

public sealed class UploadAudioCommandValidator : AbstractValidator<UploadAudioCommand>
{
    public UploadAudioCommandValidator()
    {
        RuleFor(c => c.VerificationMessageId).NotEmpty();
        RuleFor(c => c.Filename).NotEmpty();
    }
}