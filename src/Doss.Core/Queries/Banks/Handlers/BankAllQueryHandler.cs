using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Banks.Handlers;

public class BankAllQueryHandler : IRequestHandler<BankAllQuery, Result<BankAllQuery.Response>>
{
    private readonly IBankRepository bankRepository;

    public BankAllQueryHandler(IBankRepository bankRepository)
        => this.bankRepository = bankRepository;

    public async Task<Result<BankAllQuery.Response>> Handle(BankAllQuery query, CancellationToken cancellationToken)
        => Results.Ok(new BankAllQuery.Response((await bankRepository.ReturnAllAsync())
                        .Select(c => new BankAllQuery.Response.Bank(c.Id, c.Name, c.BankStatus))
                        .ToList()));
}