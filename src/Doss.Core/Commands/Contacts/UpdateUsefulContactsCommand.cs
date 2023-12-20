using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Contacts;

public class UpdateUsefulContactsCommand : Command
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Number { get; set; }
    public UsefulContactStatus Status { get; set; }
}