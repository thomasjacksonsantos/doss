using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Domain.Addresses;

public class Address
{
    public Guid Id { get; set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string Complement { get; private set; }
    public string ZipCode { get; private set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Address(string country, string state, string city, string street, string complement, string zipCode, double latitude, double longitude)
        => (Id, Country, State, City, Street, Complement, ZipCode, Latitude, Longitude) = (Guid.NewGuid(), country, state, city, street, complement, zipCode.OnlyNumbers(), latitude, longitude);

    public static implicit operator Address(OnBoardAddress address)
        => new Address(address.Country, address.State, address.City, address.Street, address.Complement, address.ZipCode.OnlyNumbers(), address.Latitude, address.Longitude);
}