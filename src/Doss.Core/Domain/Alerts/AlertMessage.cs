using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Alerts;

public class AlertMessage
{
    public Guid Id { get; private set; }
    public Guid? UserId { get; private set; }
    public AlertMessageTypeAccess TypeAccess { get; private set; }
    public bool IsRead { get; private set; }
    public string Description { get; private set; }
    public DateTime Created { get; private set; }

    public AlertMessage(bool isRead, string description, AlertMessageTypeAccess typeAccess)
        => (Id, IsRead, Description, TypeAccess, Created) = (Guid.NewGuid(), isRead, description, typeAccess, DateTime.Now);

    public AlertMessage(Guid userId, bool isRead, string description, AlertMessageTypeAccess typeAccess)
        => (Id, UserId, IsRead, Description, TypeAccess, Created) = (Guid.NewGuid(), userId, isRead, description, typeAccess, DateTime.Now);
}