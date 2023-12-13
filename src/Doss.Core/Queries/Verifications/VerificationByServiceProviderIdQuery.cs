using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Verifications;

public class VerificationByServiceProviderIdQuery : Query<VerificationByServiceProviderIdQuery.Response>
{
    public VerificationStatus Status { get; set; }
    public class Response
    {
        public Response(VerificationStatus status)
            => Status = status;
        public VerificationStatus Status { get; set; }
    }
}