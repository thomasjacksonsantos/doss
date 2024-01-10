using System.Text.Json.Serialization;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Verifications;

public class ReturnChatQuery : Query<ReturnChatQuery.Response>
{
    public Guid ResidentialVerificationRequestId { get; set; }
    public int Page { get; set; }
    public int Total { get; set; }
    public class Response
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public IEnumerable<Chat> Chats { get; set; }

        public Response(IEnumerable<Chat> chats, int page, int total)
            => (Chats, Page, Total) = (chats, page, total);
    }

    public class Chat
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public string UrlBase { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public string Photo { get; set; }
        [JsonIgnore]
        public string Audio { get; set; }
        public string PhotoUrl
            => Photo.IsNotNullOrEmpty() ? $"{UrlBase}{Photo}" : string.Empty;
        public string AudioUrl
            => Audio.IsNotNullOrEmpty() ? $"{UrlBase}{Audio}" : string.Empty;
        public DateTime When { get; set; }
        public Chat(Guid id, Guid userId, string message, string photoUrl, string audioUrl, DateTime when)
            => (Id, UserId, Message, Photo, Audio, When) = (id, userId, message, photoUrl, audioUrl, when);

        public void AddUrlBase(string urlBase)
            => UrlBase = urlBase;
    }
}