namespace Doss.Core.Domain.OnBoard;

public class OnBoardAddress
{
    public Guid Id { get; set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Neighborhood {get; private set;}
    public string Street { get; private set; }
    public string ZipCode { get; private set; }
    public string Complement { get; private set; }
    public string Number { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public OnBoardAddress(string country, string state, string city, string street, string neighborhood, string complement, string zipCode, string number, double latitude, double longitude)
        => (Country, State, City, Street, Neighborhood, Complement, ZipCode, Number, Latitude, Longitude) 
            = (country, state, city, street, neighborhood, complement, zipCode, number, latitude, longitude);

    public void ChangeCountry(string country)
        => Country = country;

    public void ChangeNumber(string number)
        => Number = number;

    public void ChangeState(string state)
        => State = state;

    public void ChangeCity(string city)
            => City = city;

    public void ChangeStreet(string street)
        => Street = street;

    public void ChangeNeighborhood(string neighborhood)
        => Neighborhood = neighborhood;

    public void ChangeComplement(string complement)
        => Complement = complement;

    public void ChangeZipCode(string zipCode)
        => ZipCode = zipCode;

    public void ChangeLatitude(double latitude)
        => Latitude = latitude;

    public void ChangeLongitude(double longitude)
        => Longitude = longitude;
}