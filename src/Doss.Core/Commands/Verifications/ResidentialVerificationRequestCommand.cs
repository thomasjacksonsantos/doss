using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class ResidentialVerificationRequestCommand : Command
{
    public Guid ResidentialWithServiceProviderId { get; set; }
    public string Message { get; set; }
}