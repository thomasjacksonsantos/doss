using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Banks;

public class UpsertBankCommand : Command
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public BankStatus BankStatus { get; set; }
}