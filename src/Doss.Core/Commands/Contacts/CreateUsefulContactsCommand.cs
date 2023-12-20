using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Contacts;

public class CreateUsefulContactsCommand : Command
{
    public string Description { get; set; } = string.Empty;

    public string Number { get; set; } = string.Empty;
}