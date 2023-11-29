namespace Doss.Core.Domain.OnBoard;

public class OnBoardAddress
{
    public Guid Id { get; set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string ZipCode { get; private set; }
    public string Complement { get; private set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public OnBoardAddress(string country, string state, string city, string street, string complement, string zipCode, double latitude, double longitude)
        => (Country, State, City, Street, Complement, ZipCode, Latitude, Longitude) = (country, state, city, street, complement, zipCode, latitude, longitude);

    public void ChangeCountry(string country)
        => Country = country;

    public void ChangeState(string state)
        => State = state;

    public void ChangeCity(string city)
            => City = city;
    public void ChangeStreet(string street)
        => Street = street;

    public void ChangeComplement(string complement)
        => Complement = complement;

    public void ChangeZipCode(string zipCode)
        => ZipCode = zipCode;

    public void ChangeLatitude(double latitude)
        => Latitude = latitude;

    public void ChangeLongitude(double longitude)
        => Longitude = longitude;
}