using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Contacts.Handlers;

public class ResidentialContactsQueryHandler : IRequestHandler<ResidentialContactsQuery, Result<ResidentialContactsQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;

    public ResidentialContactsQueryHandler(IResidentialRepository residentialRepository)
        => this.residentialRepository = residentialRepository;

    public async Task<Result<ResidentialContactsQuery.Response>> Handle(ResidentialContactsQuery query, CancellationToken cancellationToken)
        => Results.Ok(new ResidentialContactsQuery.Response(await residentialRepository.ReturnContacts(query.User!.Id, query.Page, query.Total)));
}