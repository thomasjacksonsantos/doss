using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ServiceProviderAlertByIdQuery : Query<ServiceProviderAlertByIdQuery.Response>
{    
    public int Page { get; set; }

    public class Response
    {
        public Response(IEnumerable<Message> messages)
               => Messages = messages;
        public IEnumerable<Message> Messages { get; set; }
    }

    public class Message
    {
        public Message(string description, DateTime created)
            => (Description, Created) = (description, created);
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
    }
}