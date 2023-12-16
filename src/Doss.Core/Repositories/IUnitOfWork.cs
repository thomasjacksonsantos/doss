
namespace Doss.Core.Interfaces.Repositories;

public interface IUnitOfWork
{
    IResidentialRepository ResidencialRepository { get; }
    IServiceProviderRepository ServiceProviderRepository { get; }
    IFeeRepository FeeRepository { get; }
}
