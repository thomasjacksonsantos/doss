using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Contacts;

public class CreateUsefulContactsCommand : Command
{
    public string Description { get; set; }

    public string Number { get; set; }
}