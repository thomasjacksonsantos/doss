using Doss.Core.Domain.Plans;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ReturnServiceProviderPlanTotalProfitQuery : Query<ReturnServiceProviderPlanTotalProfitQuery.Response>
{
    public class Response
    {
        public decimal TotalProfitEarn { get; set; }
        public decimal TotalByMonth { get; set; }

        public Response(decimal totalProfitEarn, decimal totalByMonth)
            => (TotalProfitEarn, TotalByMonth) = (totalProfitEarn, totalByMonth);
    }
}