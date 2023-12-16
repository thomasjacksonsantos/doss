using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Residentials;

public class ResidentialVerificationRequest
{
    public Guid Id { get; private set; }
    public Guid ResidentialWithServiceProviderId { get; set; }
    public ResidentialWithServiceProvider ResidentialWithServiceProvider { get; private set; }
    public VerificationStatus Status { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }
    public string Message { get; private set; }
    public IEnumerable<VerificationMessage> Messages { get; private set; } = new List<VerificationMessage>();

    public ResidentialVerificationRequest() { }
    
    public ResidentialVerificationRequest(ResidentialWithServiceProvider residentialWithServiceProvider, string message)
        => (ResidentialWithServiceProvider, Status, Message, Created) = (residentialWithServiceProvider, VerificationStatus.Active, message, DateTime.Now);

    public void AddMessage(Guid userId, string message, string? photo = null)
        => ((List<VerificationMessage>)Messages).Add(new VerificationMessage(userId, message, photo ?? string.Empty));

    public void ChangeStatus(VerificationStatus status)
        => Status = status;

    public class VerificationMessage
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public string Photo { get; set; }
        public VerificationMessage()
        { }

        public VerificationMessage(Guid userId, string message, string photo)
            => (UserId, Message, Photo) = (userId, message, photo);
    }
}