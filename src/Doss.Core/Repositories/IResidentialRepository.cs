using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Residentials;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.ServiceProviders;

namespace Doss.Core.Interfaces.Repositories;

public interface IResidentialRepository : IRepositoryBase<Residential>
{
    Task<ResidentialWithServiceProvider> ReturnResidentialWithServiceProvider(Guid id);
    Task AddVerificationRequest(ResidentialVerificationRequest request, bool saveChanges = false);
    Task<ResidentialInfoQuery.Response> ReturnResidentialInfo(Guid id);
    Task<ServiceProviderVerificationRequestAllQuery.Response> ReturnVerificationAllByServiceProvider(Guid id, int page, int total = 20);
    Task<ResidentialVerificationRequest> ReturnVerificationRequestById(Guid id);
    Task UpdateVerificationStatus(Guid id, VerificationStatus verificationStatus);
}