using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.Residentials;

public class ResidentialOnBoardUserInformationCommand : Command
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
}