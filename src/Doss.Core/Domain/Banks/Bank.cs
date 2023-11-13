using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Banks;

public class Bank
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public BankStatus BankStatus { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Bank(string name, BankStatus bankStatus)
        => (Id, Name, BankStatus, Created) = (Guid.NewGuid(), name, bankStatus, DateTime.Now);

    public void ChangeName(string name)
    {
        Name = name;
        Updated = DateTime.Now;
    }

    public void ChangeBankStatus(BankStatus bankStatus)
    {
        BankStatus = bankStatus;
        Updated = DateTime.Now;
    }
}