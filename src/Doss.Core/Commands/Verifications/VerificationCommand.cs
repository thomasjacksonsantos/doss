using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class VerificationCommand : Command
{
    public Guid ResidentialId { get; private set; }
    public Guid ServiceProviderId { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }
    public string Message { get; private set; }
}