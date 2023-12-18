using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class CreateServiceProviderOnBoardCompletedCommand : Command
{
    public CreateServiceProviderOnBoardCompletedCommand(Guid userId)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; set; }
}
