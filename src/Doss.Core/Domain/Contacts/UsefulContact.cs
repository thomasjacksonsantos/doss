using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Contacts;

public class UsefulContact
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Number { get; set; }
    public UsefulContactStatus Status { get; set; }
    public DateTime Created { get; set; }

    public UsefulContact() { }

    public UsefulContact(string description, string number)
        => (Description, Number) = (description, number);

    public void ChangeStatus(UsefulContactStatus status)
        => Status = status;

    public void ChangeDescription(string description)
        => Description = description;

    public void ChangeNumber(string number)
        => Number = number;
}