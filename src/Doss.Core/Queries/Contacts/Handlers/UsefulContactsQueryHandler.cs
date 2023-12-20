using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Contacts.Handlers;

public class UsefulContactsQueryHandler : IRequestHandler<UsefulContactsQuery, Result<UsefulContactsQuery.Response>>
{
    private readonly IUsefulContactRepository usefulContactRepository;

    public UsefulContactsQueryHandler(IUsefulContactRepository usefulContactRepository)
        => this.usefulContactRepository = usefulContactRepository;

    public async Task<Result<UsefulContactsQuery.Response>> Handle(UsefulContactsQuery query, CancellationToken cancellationToken)
        => Results.Ok(new UsefulContactsQuery.Response((await usefulContactRepository.ReturnAllAsync()).Select(c => new UsefulContactsQuery.Contact(c.Id, c.Description, c.Number, c.Status))));
}