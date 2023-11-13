using Doss.Core.Domain.Enums;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Verifications.Handlers;

public class VerificationByUserIdQueryHandler : IRequestHandler<VerificationByUserIdQuery, Result<VerificationByUserIdQuery.Response>>
{
    private readonly IVerificationRepository verificationRepository;

    public VerificationByUserIdQueryHandler(IVerificationRepository verificationRepository)
        => this.verificationRepository = verificationRepository;

    public async Task<Result<VerificationByUserIdQuery.Response>> Handle(VerificationByUserIdQuery query, CancellationToken cancellationToken)
    {
        var sql = @"Select VerificationStatus From Verification
                    Inner Join GuardVerification On Verification.Id = GuarVerification.VerificationId 
                    Where 
                        GuardVerification.UserId = @UserId
                    And
                        Verification.VerificationStatus = @Status";

        var verificationStatus = await verificationRepository.SqlSingleAsync<VerificationStatus>(sql, param: new { UserId = query.User!.Id, VerificationStatus.Active });

        return Results.Ok(new VerificationByUserIdQuery.Response(verificationStatus));
    }
}