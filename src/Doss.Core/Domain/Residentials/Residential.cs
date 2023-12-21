using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Residentials;

public class Residential
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public TypeDocument TypeDocument { get; private set; }
    public string Phone { get; private set; }
    public string Photo { get; private set; }
    public bool CompletedRegistration { get; private set; }
    public UserStatus UserStatus { get; private set; }    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public IEnumerable<ResidentialWithServiceProvider> ResidentialWithServiceProviders { get; set; } = new List<ResidentialWithServiceProvider>();    
    public ResidentialWithServiceProvider ReturnResidentialWithServiceProvider(Guid serviceProviderId)
        => ResidentialWithServiceProviders
            .Where(c => c.ServiceProviderPlan.ServiceProviderId == serviceProviderId)
            .FirstOrDefault()!;

    public Residential(Guid id, string name, TypeDocument typeDocument, string document, string phone, string photo, bool completedRegistration)
            => (Id, Name, TypeDocument, Document, Phone, Photo, CompletedRegistration, UserStatus, Created) = (id, name, typeDocument, document.OnlyNumbers(), phone.OnlyNumbers(), photo, completedRegistration, UserStatus.Active, DateTime.Now);

    public void AddResidentialWithServiceProvider(ResidentialWithServiceProvider residentialWithServiceProvider)
    {
        if (ResidentialWithServiceProviders is not {}) ResidentialWithServiceProviders = new List<ResidentialWithServiceProvider>();
        ((List<ResidentialWithServiceProvider>)ResidentialWithServiceProviders).Add(residentialWithServiceProvider);
    }

    public void ChangeName(string name)
        => Name = name;

    public void ChangeDocument(string document)
        => Document = document;

    public void ChangeTypeDocument(TypeDocument typeDocument)
        => TypeDocument = typeDocument;

    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangePhone(string phone)
        => Phone = phone;

    public void CompleteRegistration(bool complete)
        => CompletedRegistration = complete;

    public void ChangeUserStatus(UserStatus userStatus)
        => UserStatus = userStatus;
}