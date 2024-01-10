using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Files;

public class UploadAudioCommand : Command
{
    public Guid VerificationMessageId { get; set; }
    public string Filename { get; set; }

    public UploadAudioCommand(Guid verificationMessageId, string filename)
        => (VerificationMessageId, Filename) = (verificationMessageId, filename);
}