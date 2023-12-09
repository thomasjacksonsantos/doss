using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class UpdateServiceProviderStatusCommand : Command
{
    public UserStatus UserStatus { get; set; }
}
