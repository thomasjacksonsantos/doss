using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ServiceProviderInfoQuery : Query<ServiceProviderInfoQuery.Response>
{
    public class Response
    {
        public string Name { get; set; } = string.Empty;
        public UserStatus UserStatus { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        public void AddPhotoUrl(string url)
            => PhotoUrl = url;
    }
}