using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Verifications;

public class UpdateVerificationStatusCommand : Command
{
    public Guid Id { get; private set; }
    public VerificationStatus Status { get; private set; }
}