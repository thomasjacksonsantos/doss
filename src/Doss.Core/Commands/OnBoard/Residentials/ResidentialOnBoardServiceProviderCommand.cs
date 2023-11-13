using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.Residentials;

public class ResidentialOnBoardServiceProviderCommand : Command
{
    public Guid ServiceProviderId { get; set; }
    public Guid PlanId { get; set; }
}