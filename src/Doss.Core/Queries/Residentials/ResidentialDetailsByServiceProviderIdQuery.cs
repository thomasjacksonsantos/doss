using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Residentials;

public class ResidentialDetailsByServiceProviderIdQuery : Query<ResidentialDetailsByServiceProviderIdQuery.Response>
{
    public Guid ResidentialId { get; set; }

    public class Response
    {
        public Address Address { get; private set; }

        public Vehicle Vehicle { get; private set; }
        public Response(Address address, Vehicle vehicle)
            => (Address, Vehicle) = (address, vehicle);
    }

    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public string Photo { get; set; }
        public VehicleType VehicleType { get; set; }

        public Vehicle(string brand, string model, string color, string plate, string photo, VehicleType vehicleType)
            => (Brand, Model, Color, Plate, Photo, VehicleType) = (brand, model, color, plate, photo, vehicleType);
    }

    public class Address
    {
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public int ZipCode { get; private set; }
        public string Complement { get; private set; }

        public Address(string country, string state, string city, string neighborhood, string street, string number, int zipcode, string complement)
            => (Country, State, City, Neighborhood, Street, Number, ZipCode, Complement) = (country, state, city, neighborhood, street, number, zipcode, complement);
    }
}