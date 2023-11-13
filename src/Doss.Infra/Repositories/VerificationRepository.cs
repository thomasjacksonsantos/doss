using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Verifications;

namespace Doss.Infra.Repositories;

public class VerificationRepository : RepositoryBase<Verification>, IVerificationRepository
{
    public VerificationRepository(DossDbContext context)
        : base(context)
    {

    }
}