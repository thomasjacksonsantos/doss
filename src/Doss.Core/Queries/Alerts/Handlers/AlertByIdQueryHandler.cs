using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Alerts.Handlers;

public class AlertByIdQueryHandler : IRequestHandler<AlertByIdQuery, Result<AlertByIdQuery.Response>>
{
    private readonly IAlertMessageRepository alertMessageRepository;

    public AlertByIdQueryHandler(IAlertMessageRepository alertMessageRepository)
        => this.alertMessageRepository = alertMessageRepository;

    public async Task<Result<AlertByIdQuery.Response>> Handle(AlertByIdQuery query, CancellationToken cancellationToken)
    {
        var sql = @"Select Id, IsRead, Description, Created from AlertMessage Where UserId = @UserId Order By Created Desc ";
        var alertMessage = await alertMessageRepository.SqlListAsync(sql, new { UserId = query.User!.Id });

        return Results.Ok(new AlertByIdQuery.Response(alertMessage
                                                        .Select(c => new AlertByIdQuery.Message(c.Description, c.IsRead))
                                                        .ToList()));
    }
}