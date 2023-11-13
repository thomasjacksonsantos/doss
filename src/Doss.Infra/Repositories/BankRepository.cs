using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Banks;

namespace Doss.Infra.Repositories;

public class BankRepository : RepositoryBase<Bank>, IBankRepository
{
    public BankRepository(DossDbContext context)
        : base(context) { }
}