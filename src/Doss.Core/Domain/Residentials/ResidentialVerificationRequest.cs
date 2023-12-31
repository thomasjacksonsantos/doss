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
        => (ResidentialWithServiceProvider, Status, Message, Created) = (residentialWithServiceProvider, VerificationStatus.WaitingConfirmation, message, DateTime.Now);

    public void AddMessage(VerificationMessage verificationMessage)
        => ((List<VerificationMessage>)Messages).Add(verificationMessage);

    public void ChangeStatus(VerificationStatus status)
        => Status = status;

}
public class VerificationMessage
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ResidentialVerificationRequestId { get; set; }
    public string Message { get; set; }
    public DateTime Created { get; set; }
    public string Photo { get; set; }
    public string Audio { get; set; }
    public string PhotoUrl { get; set; }
    public string AudioUrl { get; set; }

    public VerificationMessage()
    { }

    public VerificationMessage(Guid userId, string? message = null, string? photo = null, string? audio = null)
        => (UserId, Message, Photo, Audio, PhotoUrl, AudioUrl, Created) = (userId, message ?? string.Empty, photo ?? string.Empty, audio ?? string.Empty, string.Empty, string.Empty, DateTime.Now);

    public void AddPhotoUrl(string url)
        => PhotoUrl = url;
    public void AddAudioUrl(string url)
        => AudioUrl = url;
}