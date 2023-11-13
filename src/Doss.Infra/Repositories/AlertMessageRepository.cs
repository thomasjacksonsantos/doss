
using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Alerts;

namespace Doss.Infra.Repositories;

public class AlertMessageRepository : RepositoryBase<AlertMessage>, IAlertMessageRepository
{
    public AlertMessageRepository(DossDbContext context)
        : base(context)
    {

    }
}