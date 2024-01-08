using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Images;

public class UploadImageCommand : Command
{
    public Guid VerificationMessageId { get; set; }
    public string Filename { get; set; }

    public UploadImageCommand(Guid verificationMessageId, string filename)
        => (VerificationMessageId, Filename) = (verificationMessageId, filename);
}