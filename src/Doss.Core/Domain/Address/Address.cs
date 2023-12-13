using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Domain.Addresses;

public class Address
{
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string Complement { get; private set; }
    public string ZipCode { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public string Number { get; private set; }

    public Address(string country, string state, string city, string street, string complement, string zipCode, string number, double latitude, double longitude)
        => (Country, State, City, Street, Complement, ZipCode, Number, Latitude, Longitude)
            = (country, state, city, street, complement, zipCode.OnlyNumbers(), number, latitude, longitude);

    public static implicit operator Address(OnBoardAddress address)
        => new Address(address.Country, address.State, address.City, address.Street, address.Complement, address.ZipCode.OnlyNumbers(), address.Number, address.Latitude, address.Longitude);
}