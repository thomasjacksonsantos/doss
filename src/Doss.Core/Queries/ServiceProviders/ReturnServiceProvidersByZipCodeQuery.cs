using Doss.Core.Domain.Users;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ServiceProviders;

public class ReturnServiceProvidersByZipCodeQuery : Query<IEnumerable<ServiceProvider>>
{
    public string ZipCode { get; set; } = string.Empty;
}