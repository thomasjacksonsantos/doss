using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ActiveResidentialQuery : Query<ActiveResidentialQuery.Response>
{
    public class Response
    {
        public int Total { get; set; }
        public Response(int total)
            => Total = total;
    }
}