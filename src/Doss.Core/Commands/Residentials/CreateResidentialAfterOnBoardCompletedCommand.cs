using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Residentials;

public class CreateResidentialAfterOnBoardCompletedCommand : Command
{
    public CreateResidentialAfterOnBoardCompletedCommand(Guid userId)
        => UserId = userId;
        
    public Guid UserId { get; set; }
}
