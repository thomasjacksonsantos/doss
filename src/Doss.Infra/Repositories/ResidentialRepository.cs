using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.Verifications;
using Doss.Core.Domain.Enums;
using Doss.Core.Queries.Contacts;
using Doss.Core.Seedwork;
using Dapper;

namespace Doss.Infra.Repositories;

public class ResidentialRepository : RepositoryBase<Residential>, IResidentialRepository
{
    public ResidentialRepository(DossDbContext context)
        : base(context)
    {

    }

    public override Task<Residential> ReturnByIdAsync(Guid id)
    {
        return base.ReturnByIdAsync(id);
    }

    public async Task AddVerificationRequest(ResidentialVerificationRequest request, bool saveChanges = false)
    {
        await Context.AddAsync(request);

        if (saveChanges)
            await Context.SaveChangesAsync();
    }

    public async Task<ResidentialWithServiceProvider> ReturnResidentialWithServiceProvider(Guid id)
    {
        return await Context.ResidentialWithServiceProvider
                            .Include(c => c.ServiceProviderPlan)
                            .ThenInclude(c => c.ServiceProvider)
                            .AsSplitQuery()
                            .FirstOrDefaultAsync(c => c.Id == id) ?? null!;
    }

    public async Task<ResidentialInfoQuery.Response> ReturnResidentialInfo(Guid id)
    {
        return await Context.Residential
                    .Include(c => c.ResidentialWithServiceProviders)
                    .Where(c => c.Id == id)
                    .Select(c => new ResidentialInfoQuery.Response(c.Id, c.Name, c.UserStatus, c.Photo, c.ResidentialWithServiceProviders.First().Id))
                    .FirstOrDefaultAsync() ?? null!;
    }

    public async Task<Residential> ReturnVehicles(Guid id, Guid residentialWithServiceProviderId)
        => await Context.Residential
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.ResidentialVehicles)!
                    .ThenInclude(c => c.Vehicle)
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.ServiceProviderPlan)
                    .Where(c => c.Id == id && c.ResidentialWithServiceProviders.Select(c => c.Id).Contains(residentialWithServiceProviderId))
                    .SingleOrDefaultAsync() ?? null!;

    public async Task<ServiceProviderVerificationRequestAllQuery.Response> ReturnVerificationAllByServiceProvider(Guid id, int page, int total = 20)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        var verifications = await Context.ResidentialVerificationRequest
                                     .Where(c => c.ResidentialWithServiceProvider.ServiceProviderPlan.ServiceProviderId == id)
                                     .Select(c => new ServiceProviderVerificationRequestAllQuery
                                                    .Verification(c.Id,
                                                                    c.Message,
                                                                    c.Created,
                                                                    new ServiceProviderVerificationRequestAllQuery
                                                                        .Residential(c.ResidentialWithServiceProvider.Residential.Name, c.ResidentialWithServiceProvider.Residential.Photo),
                                                                    new ServiceProviderVerificationRequestAllQuery
                                                                        .Address(c.ResidentialWithServiceProvider.Address.State,
                                                                                c.ResidentialWithServiceProvider.Address.City,
                                                                                c.ResidentialWithServiceProvider.Address.Street,
                                                                                c.ResidentialWithServiceProvider.Address.Number,
                                                                                c.ResidentialWithServiceProvider.Address.ZipCode)))
                                                                                .Skip(page)
                                                                                .Take(total)
                                                                                .ToListAsync();

        return new ServiceProviderVerificationRequestAllQuery.Response(verifications);
    }

    public async Task UpdateVerificationStatus(Guid id, VerificationStatus verificationStatus)
        => await Connection.ExecuteAsync(sql: "UPDATE Doss.ResidentialVerificationRequest Set [Status] = @VerificationStatus WHERE Id = @Id",
                                      param: new { Id = id, VerificationStatus = verificationStatus.ToString() });

    public async Task<ResidentialVerificationRequest> ReturnVerificationRequestById(Guid id)
    {
        return await Context.ResidentialVerificationRequest
                        .Include(c => c.Messages)
                        .SingleOrDefaultAsync(c => c.Id == id) ?? null!;
    }

    public async Task<IEnumerable<ReturnChatQuery.Chat>> ReturnChatMessage(Guid residentialVerificationRequestId, int page, int total)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        return await Context.VerificationMessage
                .OrderByDescending(c => c.Created)
                .Where(c => c.ResidentialVerificationRequestId == residentialVerificationRequestId)
                .Skip(page)
                .Take(total)
                .Select(c => new ReturnChatQuery.Chat(c.Id, c.UserId, c.Message, c.Photo, c.Audio, c.Created))
                .ToListAsync();
    }

    public async Task<IEnumerable<ResidentialContactsQuery.Contact>> ReturnContacts(Guid serviceProviderId, int page, int total = 20)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        return await Context
                    .Residential
                    .Where(c => c.ResidentialWithServiceProviders
                                .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                .Contains(serviceProviderId))
                .Skip(page)
                .Take(total)
                .Select(c => new ResidentialContactsQuery.Contact(c.Id, c.Name, c.Phone, c.Photo))
                .ToListAsync();
    }

    public async Task<IEnumerable<ResidentialListByServiceProviderIdQuery.Residential>> ReturnResidentialList(Guid serviceProviderId, int page, int total = 20, UserStatus? status = null)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        return await Context
                    .Residential
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.ServiceProviderPlan)
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.Plan)
                    .Where(c => c.ResidentialWithServiceProviders
                                .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                .Contains(serviceProviderId) && status.IsNotNull() ? c.UserStatus == status : 0 == 0)
                    .Skip(page)
                    .Take(total)
                    .Select(c => new ResidentialListByServiceProviderIdQuery.Residential(c.Id, c.Name, c.UserStatus, c.Photo, c.ResidentialWithServiceProviders.First().Plan.Description))
                    .ToListAsync();
    }

    public async Task<ResidentialDetailsByServiceProviderIdQuery.Response> ReturnResidentialDetails(Guid residentialId, Guid serviceProviderId)
    {
        var residential = await Context
                                .Residential
                                .Include(c => c.ResidentialWithServiceProviders)
                                .ThenInclude(c => c.ResidentialVehicles)!
                                .ThenInclude(c => c.Vehicle)
                                .Include(c => c.ResidentialWithServiceProviders)
                                .ThenInclude(c => c.Address)
                                .Where(c => c.ResidentialWithServiceProviders
                                            .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                            .Contains(serviceProviderId) && c.Id == residentialId)
                                .FirstOrDefaultAsync();

        var residentialWithServiceProvider = residential!.ReturnResidentialWithServiceProvider(serviceProviderId);

        return new ResidentialDetailsByServiceProviderIdQuery.Response(new ResidentialDetailsByServiceProviderIdQuery.Address(residentialWithServiceProvider.Address.Country,
                                                                                                                                         residentialWithServiceProvider.Address.State,
                                                                                                                                         residentialWithServiceProvider.Address.City,
                                                                                                                                         residentialWithServiceProvider.Address.Neighborhood,
                                                                                                                                         residentialWithServiceProvider.Address.Street,
                                                                                                                                         residentialWithServiceProvider.Address.Number,
                                                                                                                                         residentialWithServiceProvider.Address.ZipCode,
                                                                                                                                         residentialWithServiceProvider.Address.Complement),
                                                                                  new ResidentialDetailsByServiceProviderIdQuery.Vehicle(residentialWithServiceProvider.VehicleDefault.Brand,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Model,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Color,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Plate,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Photo,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.VehicleType));
    }

    public async Task<ActiveResidentialQuery.Response> ReturnTotalActive(Guid serviceProviderId)
        => new ActiveResidentialQuery.Response(await Context
                    .Residential
                    .Where(c => c.ResidentialWithServiceProviders
                                .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                .Contains(serviceProviderId))
                    .CountAsync());
}