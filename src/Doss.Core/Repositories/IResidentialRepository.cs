using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Residentials;
using Doss.Core.Queries.Contacts;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.Verifications;

namespace Doss.Core.Interfaces.Repositories;

public interface IResidentialRepository : IRepositoryBase<Residential>
{
    Task<ResidentialWithServiceProvider> ReturnResidentialWithServiceProvider(Guid id);
    Task AddVerificationRequest(ResidentialVerificationRequest request, bool saveChanges = false);
    Task<ResidentialInfoQuery.Response> ReturnResidentialInfo(Guid id);
    Task<ServiceProviderVerificationRequestAllQuery.Response> ReturnVerificationAllByServiceProvider(Guid id, int page, int total = 20);
    Task<ResidentialVerificationRequest> ReturnVerificationRequestById(Guid id);
    Task UpdateVerificationStatus(Guid id, VerificationStatus verificationStatus);
    Task<IEnumerable<ReturnChatQuery.Chat>> ReturnChatMessage(Guid residentialVerificationRequestId, int page, int total = 20);
    Task<IEnumerable<ResidentialContactsQuery.Contact>> ReturnContacts(Guid serviceProviderId, int page, int total = 20);
    Task<IEnumerable<ResidentialListByServiceProviderIdQuery.Residential>> ReturnResidentialList(Guid serviceProviderId, int page, int total = 20, UserStatus? status = null);
    Task<ResidentialDetailsByServiceProviderIdQuery.Response> ReturnResidentialDetails(Guid residentialId, Guid serviceProviderId);
    Task<Residential> ReturnVehicles(Guid id, Guid residentialWithServiceProviderId);
    Task<ActiveResidentialQuery.Response> ReturnTotalActive(Guid serviceProviderId);
}