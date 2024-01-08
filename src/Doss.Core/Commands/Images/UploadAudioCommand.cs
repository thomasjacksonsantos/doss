namespace Doss.Core.Commands.Images;

public class UploadAudioCommand
{
    public Guid VerificationMessageId { get; set; }
    public string Filename { get; set; }

    public UploadAudioCommand(Guid verificationMessageId, string filename)
        => (VerificationMessageId, Filename) = (verificationMessageId, filename);
}