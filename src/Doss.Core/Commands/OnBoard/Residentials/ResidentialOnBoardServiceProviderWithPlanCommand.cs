using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.Residentials;

public class ResidentialOnBoardServiceProviderWithPlanCommand : Command
{
    public Guid ServiceProviderPlanId { get; set; }
    public Guid PlanId { get; set; }
}