using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Contacts;

public class UpdateUsefulContactsCommand : Command
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public UsefulContactStatus Status { get; set; }
}