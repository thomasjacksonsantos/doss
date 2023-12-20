using System.Text.Json.Serialization;
using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Contacts;

public class UsefulContactsQuery : Query<UsefulContactsQuery.Response>
{
    public class Response
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public Response(IEnumerable<Contact> contacts)
            => Contacts = contacts;
    }

    public class Contact
    {
        public Guid Id { get; set; }
        public string Description { get; private set; }
        public string Number { get; private set; }
        public UsefulContactStatus Status { get; private set; }
        public Contact(Guid id, string description, string number, UsefulContactStatus status)
            => (Id, Description, Number, Status) = (id, description, number, status);
    }
}