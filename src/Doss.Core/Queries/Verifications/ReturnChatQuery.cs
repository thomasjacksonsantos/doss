using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Verifications;

public class ReturnChatQuery : Query<ReturnChatQuery.Response>
{
    public Guid ResidentialVerificationRequestId { get; set; }
    public int Page { get; set; }
    public int Total { get; set; }
    public class Response
    {
        public IEnumerable<Chat> Chats { get; set; }

        public Response(IEnumerable<Chat> chats)
            => Chats = chats;
    }

    public class Chat
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string Photo { get; set; }
        public string Audio { get; set; }
        public DateTime When { get; set; }
        public Chat(Guid id, Guid userId, string message, string photo, string audio, DateTime when)
            => (Id, UserId, Message, Photo, Audio, When) = (id, userId, message, photo, audio, when);
    }
}