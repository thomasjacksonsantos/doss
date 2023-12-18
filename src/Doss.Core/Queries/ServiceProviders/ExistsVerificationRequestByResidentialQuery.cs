using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ExistsVerificationRequestByResidentialQuery : Query<ExistsVerificationRequestByResidentialQuery.Response>
{
    public class Response
    {
        public int Total { get; set; }
        public bool ExistsVerificationRequest 
            => Total > 0;
    }
}