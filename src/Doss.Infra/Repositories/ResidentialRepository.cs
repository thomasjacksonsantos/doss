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
using Microsoft.Extensions.Options;
using Doss.Core.Domain.Settings;
using Doss.Core.Queries.ServiceProviders;

namespace Doss.Infra.Repositories;

public class ResidentialRepository : RepositoryBase<Residential>, IResidentialRepository
{
    private readonly AppSettings appSettings;

    public ResidentialRepository(IOptions<AppSettings> options, DossDbContext context)
        : base(context)
            => (appSettings) = (options.Value);

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
                    .Select(c => new ResidentialInfoQuery.Response(c.Id, c.Name, c.UserStatus, c.PhotoUrl, c.ResidentialWithServiceProviders.First().Id))
                    .FirstOrDefaultAsync() ?? null!;
    }

    public async Task<string> ReturnPhotoUrl(Guid id)
        => await Context.Residential.Where(c => c.Id == id)
            .Select(c => c.PhotoUrl)
            .SingleAsync();

    public async Task<Residential> ReturnVehicles(Guid id, Guid residentialWithServiceProviderId)
        => await Context.Residential
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.ResidentialVehicles)!
                    .ThenInclude(c => c.Vehicle)
                    .Include(c => c.ResidentialWithServiceProviders)
                    .ThenInclude(c => c.ServiceProviderPlan)
                    .Where(c => c.Id == id && c.ResidentialWithServiceProviders.Select(c => c.Id).Contains(residentialWithServiceProviderId))
                    .SingleOrDefaultAsync() ?? null!;

    public async Task<ServiceProviderVerificationRequestAllQuery.Response> ReturnVerificationAllByServiceProvider(Guid id, VerificationStatus status, int page, int total = 20)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        var verifications = await Context.ResidentialVerificationRequest
                                    .Include(c => c.ResidentialWithServiceProvider)
                                    .ThenInclude(c => c.ServiceProviderPlan)
                                    .ThenInclude(c => c.Address)
                                    .Where(c => c.ResidentialWithServiceProvider.ServiceProviderPlan.ServiceProviderId == id && c.Status == status)
                                    .Select(c => new ServiceProviderVerificationRequestAllQuery
                                                    .Verification(c.Id,
                                                                    c.Message,
                                                                    c.Created,
                                                                    new ServiceProviderVerificationRequestAllQuery
                                                                        .Residential(c.ResidentialWithServiceProvider.Residential.Name, $"{appSettings.Files.DownloadImageUrl}/{c.ResidentialWithServiceProvider.Residential.PhotoUrl}"),
                                                                    new ServiceProviderVerificationRequestAllQuery
                                                                        .Address(c.ResidentialWithServiceProvider.Address.State,
                                                                                c.ResidentialWithServiceProvider.Address.City,
                                                                                c.ResidentialWithServiceProvider.Address.Street,
                                                                                c.ResidentialWithServiceProvider.Address.Number,
                                                                                c.ResidentialWithServiceProvider.Address.ZipCode,
                                                                                c.ResidentialWithServiceProvider.Address.Latitude,
                                                                                c.ResidentialWithServiceProvider.Address.Longitude)))
                                                                                .Skip(page)
                                                                                .Take(total)
                                                                                .ToListAsync();

        return new ServiceProviderVerificationRequestAllQuery.Response(verifications);
    }

    public async Task UpdateVerificationStatus(Guid id, VerificationStatus verificationStatus)
        => await Connection.ExecuteAsync(sql: "UPDATE Doss.ResidentialVerificationRequest Set [Status] = @VerificationStatus WHERE Id = @Id",
                                      param: new { Id = id, VerificationStatus = verificationStatus.ToString() });

    public async Task<ResidentialVerificationRequest> ReturnVerificationRequestById(Guid id)
        => await Context.ResidentialVerificationRequest
                        .Include(c => c.Messages)
                        .Include(c => c.ResidentialWithServiceProvider)
                        .SingleOrDefaultAsync(c => c.Id == id) ?? null!;

    public async Task<ReturnChatQuery.Response> ReturnChatMessage(Guid residentialVerificationRequestId, int page, int total)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        var totalResult = await Context.VerificationMessage
                                 .Where(c => c.ResidentialVerificationRequestId == residentialVerificationRequestId)
                                 .CountAsync();

        var messages = await Context.VerificationMessage
                .OrderByDescending(c => c.Created)
                .Where(c => c.ResidentialVerificationRequestId == residentialVerificationRequestId)
                .Skip(page)
                .Take(total)
                .Select(c => new ReturnChatQuery.Chat(c.Id, c.UserId, c.Message, c.PhotoUrl, c.AudioUrl, c.Created))
                .ToListAsync();

        return new ReturnChatQuery.Response(messages, (page + 1), totalResult);
    }

    public async Task<VerificationMessage> ReturnChatMessageById(Guid verificationMessageId)
        => await Context.VerificationMessage.SingleAsync(c => c.Id == verificationMessageId);

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

    public async Task<ResidentialListByServiceProviderIdQuery.Response> ReturnResidentialList(Guid serviceProviderId, int page, int total = 20, ResidentialWithServiceProviderStatus? status = null)
    {
        if (total <= 0 || total > 20)
            total = 20;

        if (page > 0)
            page = (page - 1) * total;

        var totalResult = await Context
                                    .Residential
                                    .Where(c => c.ResidentialWithServiceProviders
                                                .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                                .Contains(serviceProviderId) && status.IsNotNull()
                                                    ? c.ResidentialWithServiceProviders
                                                            .Where(c => c.ResidentialWithServiceProviderStatus == status)
                                                            .Any()
                                                    : 0 == 0)
                                    .CountAsync();

        var residentials = await Context
                            .Residential
                            .Include(c => c.ResidentialWithServiceProviders)
                            .ThenInclude(c => c.ServiceProviderPlan)
                            .Include(c => c.ResidentialWithServiceProviders)
                            .ThenInclude(c => c.Plan)
                            .AsSplitQuery()
                            .Where(c => c.ResidentialWithServiceProviders
                                        .Select(c => c.ServiceProviderPlan.ServiceProviderId)
                                        .Contains(serviceProviderId) && status.IsNotNull()
                                            ? c.ResidentialWithServiceProviders
                                                .Where(c => c.ResidentialWithServiceProviderStatus == status)
                                                .Any()
                                            : 0 == 0)
                            .Skip(page)
                            .Take(total)
                            .Select(c => new ResidentialListByServiceProviderIdQuery.Residential(c.Id, c.Name, c.UserStatus, c.PhotoUrl, c.ResidentialWithServiceProviders.First().Plan.Description))
                            .ToListAsync();

        return new ResidentialListByServiceProviderIdQuery.Response(residentials, totalResult);
    }

    public async Task<ResidentialDetailsByServiceProviderIdQuery.Response> ReturnResidentialDetails(Guid residentialId, Guid serviceProviderId)
    {
        var residentialWithServiceProvider = await Context
                                .ResidentialWithServiceProvider
                                .Include(c => c.ResidentialVehicles)!
                                .ThenInclude(c => c.Vehicle)
                                .Include(c => c.Address)
                                .FirstOrDefaultAsync(c => c.ServiceProviderPlan.ServiceProviderId == serviceProviderId && c.ResidentialId == residentialId);

        return new ResidentialDetailsByServiceProviderIdQuery.Response(new ResidentialDetailsByServiceProviderIdQuery.Address(residentialWithServiceProvider!.Address.Country,
                                                                                                                                         residentialWithServiceProvider.Address.State,
                                                                                                                                         residentialWithServiceProvider.Address.City,
                                                                                                                                         residentialWithServiceProvider.Address.Neighborhood,
                                                                                                                                         residentialWithServiceProvider.Address.Street,
                                                                                                                                         residentialWithServiceProvider.Address.Number,
                                                                                                                                         residentialWithServiceProvider.Address.ZipCode,
                                                                                                                                         residentialWithServiceProvider.Address.Complement,
                                                                                                                                         residentialWithServiceProvider.Address.Latitude,
                                                                                                                                         residentialWithServiceProvider.Address.Longitude),
                                                                                  new ResidentialDetailsByServiceProviderIdQuery.Vehicle(residentialWithServiceProvider.VehicleDefault.Brand,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Model,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Color,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.Plate,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.PhotoUrl,
                                                                                                                                         residentialWithServiceProvider.VehicleDefault.VehicleType));
    }

    public async Task<ActiveResidentialQuery.Response> ReturnTotalActive(Guid serviceProviderId)
        => new ActiveResidentialQuery.Response(await Context
                    .Residential
                    .Where(c => c.ResidentialWithServiceProviders
                                .Where(c => c.ServiceProviderPlan.ServiceProviderId == serviceProviderId
                                        && c.ResidentialWithServiceProviderStatus == ResidentialWithServiceProviderStatus.Active)
                                            .Any())
                    .CountAsync());


    public async Task<ReturnServiceProviderPlanTotalProfitQuery.Response> ReturnTotalProfit(Guid serviceProviderId)
    {
        var totalActiveByCustomers = await Context.ResidentialWithServiceProvider
                 .Where(c => c.ServiceProviderPlan.ServiceProviderId == serviceProviderId
                             && c.ResidentialWithServiceProviderStatus == ResidentialWithServiceProviderStatus.Active)
                 .SumAsync(c => c.Plan.Price);

        var totalProfitEarn = await Context.ResidentialWithServiceProvider
                 .Where(c => c.ServiceProviderPlan.ServiceProviderId == serviceProviderId)
                 .SumAsync(c => c.Plan.Price);

        return new ReturnServiceProviderPlanTotalProfitQuery.Response(totalProfitEarn, totalActiveByCustomers);
    }
}