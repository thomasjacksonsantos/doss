using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Users;

public class Residential : User
{
    public IEnumerable<Address> Addresses { get; private set; } = new List<Address>();
    public IEnumerable<ResidentialWithServiceProvider> ResidentialWithServiceProviders { get; set; } = new List<ResidentialWithServiceProvider>();

    public Residential(Guid userId, string name, TypeDocument typeDocument, string document, string phone, string photo, bool completedRegistration)
        : base(userId, name, typeDocument, document, phone, photo, completedRegistration) { }

    public void AddAddress(IEnumerable<Address> addresses)
    => Addresses = addresses;

    public void AddAddress(Address address)
        => ((List<Address>)Addresses!).Add(address);
}