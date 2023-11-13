using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Queries.Banks;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ServiceProvidersOnBoard.Handlers;

public class ReturnServiceProviderOnBoardByIdQueryHandler : IRequestHandler<ReturnServiceProviderOnBoardByIdQuery, Result<OnBoardServiceProvider>>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;

    public ReturnServiceProviderOnBoardByIdQueryHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository)
        => this.onBoardServiceProviderRepository = onBoardServiceProviderRepository;

    public async Task<Result<OnBoardServiceProvider>> Handle(ReturnServiceProviderOnBoardByIdQuery query, CancellationToken cancellationToken)
    {
        var onBoardServiceProvider = await onBoardServiceProviderRepository.ReturnByUserIdAsync(query.Id);
        if (onBoardServiceProvider.IsNotNull())
            return Results.Ok(onBoardServiceProvider);

        return Results.Error<OnBoardServiceProvider>("Not found.");
    }
}