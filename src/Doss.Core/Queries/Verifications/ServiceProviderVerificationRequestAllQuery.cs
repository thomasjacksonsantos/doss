using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Verifications;

public class ServiceProviderVerificationRequestAllQuery : Query<ServiceProviderVerificationRequestAllQuery.Response>
{
    public int Page { get; set; }
    public int Total { get; set; }
    public VerificationStatus Status { get; set; }
    public class Response
    {
        public IEnumerable<Verification> Verifications { get; set; }
        public Response(IEnumerable<Verification> verifications)
            => (Verifications) = (verifications);
    }

    public class Verification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime When { get; set; }
        public Address Address { get; set; }
        public Residential Residential { get; set; }
        public Verification(Guid id, string message, DateTime when, Residential residential, Address address)
            => (Id, Message, When, Residential, Address) = (id, message, when, residential, address);
    }

    public class Residential
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public Residential(string name, string photoUrl)
            => (Name, PhotoUrl) = (name, photoUrl);
    }

    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Number { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Address(string state, string city, string street, string number, string zipcode, double latitude, double longitude)
            => (State, City, Street, Number, ZipCode, Latitude, Longitude) = (state, city, street, number, zipcode, latitude, longitude);
    }
}