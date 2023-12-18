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
        public string Photo { get; set; }
        public Residential(string name, string photo)
            => (Name, Photo) = (name, photo);
    }

    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string Number { get; set; }
        public Address(string state, string city, string street, string number, int zipcode)
            => (State, City, Street, Number, ZipCode) = (state, city, street, number, zipcode);
    }
}