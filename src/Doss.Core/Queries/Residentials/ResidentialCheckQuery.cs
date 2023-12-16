using System.Text.Json.Serialization;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Residentials;

public class ResidentialCheckQuery : Query<ResidentialCheckQuery.Response>
{
   public class Response
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        
        public bool CompletedRegistration
            => UserId.IsNotNull();
    }
}