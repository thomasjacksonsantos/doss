using Doss.Core.Domain.Settings;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Microsoft.Extensions.Options;
using MediatR;

namespace Doss.Core.Queries.Contacts.Handlers;

public class ResidentialContactsQueryHandler : IRequestHandler<ResidentialContactsQuery, Result<ResidentialContactsQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly AppSettings appSettings;

    public ResidentialContactsQueryHandler(IResidentialRepository residentialRepository,
                                           IOptions<AppSettings> appSettings)
        => (this.residentialRepository, this.appSettings) = (residentialRepository, appSettings.Value);

    public async Task<Result<ResidentialContactsQuery.Response>> Handle(ResidentialContactsQuery query, CancellationToken cancellationToken)
    {
        var contacts = await residentialRepository.ReturnContacts(query.User!.Id, query.Page, query.Total);
        contacts.ForEach(c => c.ChangePhoto($"{appSettings.Files.DownloadImageUrl}/{c.Photo}"));
        return Results.Ok(new ResidentialContactsQuery.Response(contacts));
    }
}