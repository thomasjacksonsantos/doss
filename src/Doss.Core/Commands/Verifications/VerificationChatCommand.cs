using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class VerificationChatCommand : Command
{
    public Guid ResidentialVerificationRequestId { get; set; }
    public string Message { get; set; }
    public string? Photo { get; set; }
}
