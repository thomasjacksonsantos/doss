using System.Text.Json.Serialization;
using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Residentials;

public class ResidentialInfoQuery : Query<ResidentialInfoQuery.Response>
{
    public class Response
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public string Photo { get; private set; }
        public Guid ResidentialWithServiceProviderId { get; private set; }

        public Response(Guid id, string name, UserStatus userStatus, string photo, Guid residentialWithServiceProviderId)
            => (Id, Name, UserStatus, Photo, ResidentialWithServiceProviderId) = (id, name, userStatus, photo, residentialWithServiceProviderId);
    }
}