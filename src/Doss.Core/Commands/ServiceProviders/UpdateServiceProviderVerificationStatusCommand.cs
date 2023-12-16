using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class UpdateServiceProviderVerificationStatusCommand : Command
{
    public Guid VerificationId { get; set; }
    public VerificationStatus Status { get; set; }
}
