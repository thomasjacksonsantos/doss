using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ReturnServiceProvidersByZipCodeQuery : Query<IEnumerable<ServiceProvider>>
{
    public string ZipCode { get; set; } = string.Empty;
}