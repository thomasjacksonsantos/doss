using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class UpdateServiceProviderVerificationStatusCommand : Command
{
    public Guid VerificationId { get; set; }
    public VerificationStatus Status { get; set; }
}
