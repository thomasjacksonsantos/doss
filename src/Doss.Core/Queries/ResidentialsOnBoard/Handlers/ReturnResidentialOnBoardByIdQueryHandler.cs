using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.ResidentialsOnBoard.Handlers;

public class ReturnResidentialOnBoardByIdQueryHandler : IRequestHandler<ReturnResidentialOnBoardByIdQuery, Result<OnBoardResidential>>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;

    public ReturnResidentialOnBoardByIdQueryHandler(IOnBoardResidentialRepository onBoardResidentialRepository)
        => this.onBoardResidentialRepository = onBoardResidentialRepository;

    public async Task<Result<OnBoardResidential>> Handle(ReturnResidentialOnBoardByIdQuery query, CancellationToken cancellationToken)
    {
        var onBoardResidential = await onBoardResidentialRepository.ReturnByUserIdAsync(query.Id);
        if (onBoardResidential.IsNotNull())
            return Results.Ok(onBoardResidential);

        return Results.Error<OnBoardResidential>("Not found.");
    }
}