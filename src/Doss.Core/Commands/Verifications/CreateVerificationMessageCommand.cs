using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class CreateVerificationMessageCommand : Command
{
    public Guid ResidentialVerificationRequestId { get; set; }
    public string Message { get; set; }
    public string? Photo { get; set; }
}
