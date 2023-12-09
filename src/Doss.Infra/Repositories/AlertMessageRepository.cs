
using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.ServiceProviders;

namespace Doss.Infra.Repositories;

public class ServiceProviderAlertRepository : RepositoryBase<ServiceProviderAlert>, IServiceProviderAlertRepository
{
    public ServiceProviderAlertRepository(DossDbContext context)
        : base(context)
    {

    }
}