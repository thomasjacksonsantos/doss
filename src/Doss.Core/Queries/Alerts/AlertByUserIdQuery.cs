using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Alerts;

public class AlertByIdQuery : Query<AlertByIdQuery.Response>
{
    public class Response
    {
        public Response(IEnumerable<Message> messages)
               => Messages = messages;
        public bool ShowAlert
            => Messages.Any(c => c.IsRead is false);
        public IEnumerable<Message> Messages { get; set; }
    }

    public class Message
    {
        public Message(string description, bool isRead)
            => (Description, IsRead) = (description, isRead);
        public string Description { get; set; }
        public bool IsRead { get; set; }
    }
}