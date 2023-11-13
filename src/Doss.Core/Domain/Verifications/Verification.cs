using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Verifications;

public class Verification
{
    public Guid Id { get; private set; }
    public Guid ResidentialId { get; private set; }
    public Guid ServiceProviderId { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }
    public VerificationStatus Status { get; private set; }
    public string Title { get; private set; }
    public IEnumerable<Message> Messages { get; private set; } = new List<Message>();

    public Verification(Guid serviceProviderId, Guid residentialId, string title)
        => (ServiceProviderId, ResidentialId, Status, Title, Created) = (serviceProviderId, residentialId, VerificationStatus.Active, title, DateTime.Now);

    public void AddMessage(Guid userId, string text, string? photo = null)
        => ((List<Message>)Messages).Add(new Message(userId, text, photo ?? string.Empty));

    public void ChangeStatus(VerificationStatus status)
        => Status = status;

    public class Message
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public string Photo { get; set; }
        public Message(Guid userId, string message, string photo)
            => (UserId, Text, Photo) = (userId, message, photo);
    }
}