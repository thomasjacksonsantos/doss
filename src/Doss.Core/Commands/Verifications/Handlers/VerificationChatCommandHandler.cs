using Doss.Core.Commands.Images;
using Doss.Core.Domain.Residentials;
using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Doss.Core.Commands.Verifications.Handlers;

public class VerificationChatCommandHandler : BaseCommandHandler<VerificationChatCommand, VerificationChatCommandValidator>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IServiceBus serviceBus;
    private readonly AppSettings appSettings;
    public VerificationChatCommandHandler(IUnitOfWork unitOfWork,
                                          IServiceBus serviceBus,
                                          IOptions<AppSettings> appSettings,
                                          VerificationChatCommandValidator validator)
        : base(validator)
            => (this.serviceBus, this.unitOfWork, this.appSettings) = (serviceBus, unitOfWork, appSettings.Value);

    public override async Task<Result> HandleImplementation(VerificationChatCommand command)
    {
        if (command.Message.IsNull() && command.Photo.IsNull() && command.Audio.IsNull())
            return Results.Error("Message is empty");

        var verification = await unitOfWork.ResidencialRepository.ReturnVerificationRequestById(command.ResidentialVerificationRequestId);

        var verificationMessage = new VerificationMessage(command.User!.Id, message: command.Message, photo: command.Photo, audio: command.Audio);

        verification.AddMessage(verificationMessage);
        await unitOfWork.ServiceProviderRepository.SaveAsync();

        if (command.Photo.IsNotNull())
            await serviceBus.SendAsync(new UploadImageCommand(verificationMessage.Id, $"verification-chat/image/{verificationMessage.Id}"), appSettings.ServiceBusTopicOrQueueName.UploadImage);

        if (command.Audio.IsNotNull())
            await serviceBus.SendAsync(new UploadAudioCommand(verificationMessage.Id, $"verification-chat/audio/{verificationMessage.Id}"), appSettings.ServiceBusTopicOrQueueName.UploadAudio);

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