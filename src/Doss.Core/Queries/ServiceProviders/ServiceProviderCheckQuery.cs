using System.Text.Json.Serialization;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ServiceProviderCheckQuery : Query<ServiceProviderCheckQuery.Response>
{
    public class Response
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        
        public bool CompletedRegistration
            => UserId.IsNotNull();
    }
}