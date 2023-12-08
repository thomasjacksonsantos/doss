using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class ServiceProviderOnBoardCompletedCommand : Command
{
    public ServiceProviderOnBoardCompletedCommand(Guid userId)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; set; }
}
