
namespace Doss.Core.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IResidentialRepository ResidencialRepository { get; set; }
    IServiceProviderRepository ServiceProviderRepository { get; set; }
    IFeeRepository FeeRepository { get; set; }
}
