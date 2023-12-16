using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class ResidentialVerificationRequestCommand : Command
{
    public Guid ResidentialWithServiceProviderId { get; private set; }
    public string Message { get; private set; }
}