using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Contacts;

public class ResidentialContactsQuery : Query<ResidentialContactsQuery.Response>
{
    public int Page { get; set; }
    public int Total { get; set; }
    public class Response
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public Response(IEnumerable<Contact> contacts)
            => Contacts = contacts;
    }

    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Number { get; private set; }
        public string Photo { get; set; }
        public Contact(Guid id, string name, string number, string photo)
            => (Id, Name, Number, Photo) = (id, name, number, photo);
    }
}