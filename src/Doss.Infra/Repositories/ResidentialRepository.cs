using Doss.Infra.Data;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Domain.Residentials;
using Microsoft.EntityFrameworkCore;
using Doss.Core.Queries.Residentials;
using Doss.Core.Queries.Verifications;
using Doss.Core.Domain.Enums;
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
                    .Select(c => new ResidentialInfoQuery.Response(c.Id, c.Name, c.UserStatus, c.Photo, c.ResidentialWithServiceProviders.First().Id))
                    .SingleOrDefaultAsync(c => c.Id == id) ?? null!;
    }

    public async Task<ServiceProviderVerificationRequestAllQuery.Response> ReturnVerificationAllByServiceProvider(Guid id, int page, int total = 20)
    {
        if (total <= 0)
            total = 20;

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
                                                                                .Skip((page - 1) * total)
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
        if (total <= 0)
            total = 20;

        return await Context.VerificationMessage
                .OrderByDescending(c => c.Created)
                .Where(c => c.ResidentialVerificationRequestId == residentialVerificationRequestId)
                .Skip((page - 1) * total)
                .Take(total)
                .Select(c => new ReturnChatQuery.Chat(c.Id, c.UserId, c.Message, c.Photo, c.Created))
                .ToListAsync();
    }
}