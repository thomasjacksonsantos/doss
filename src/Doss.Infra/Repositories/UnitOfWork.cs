using Doss.Core.Interfaces.Repositories;
using Doss.Infra.Data;

namespace Doss.Infra.Repositories;

public class UnitOfWork : RepositoryBase<DossDbContext>, IUnitOfWork
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IFeeRepository feeRepository;

    public UnitOfWork(DossDbContext dbContext,
                      IResidentialRepository residentialRepository,
                      IServiceProviderRepository serviceProviderRepository,
                      IFeeRepository feeRepository)
        : base(dbContext)
            => (this.residentialRepository, this.serviceProviderRepository, this.feeRepository)
            = (residentialRepository, serviceProviderRepository, feeRepository);


    public IResidentialRepository ResidencialRepository
        => residentialRepository;

    public IServiceProviderRepository ServiceProviderRepository
        => serviceProviderRepository;

    public IFeeRepository FeeRepository
        => feeRepository;

    public async Task CommitAsync()
        => await Context.SaveChangesAsync();

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}