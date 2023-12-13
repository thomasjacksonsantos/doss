using Doss.Core.Domain.Enums;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using MediatR;

namespace Doss.Core.Queries.Verifications.Handlers;

public class VerificationByServiceProviderIdQueryHandler : IRequestHandler<VerificationByServiceProviderIdQuery, Result<VerificationByServiceProviderIdQuery.Response>>
{
    private readonly IVerificationRepository verificationRepository;

    public VerificationByServiceProviderIdQueryHandler(IVerificationRepository verificationRepository)
        => this.verificationRepository = verificationRepository;

    public async Task<Result<VerificationByServiceProviderIdQuery.Response>> Handle(VerificationByServiceProviderIdQuery query, CancellationToken cancellationToken)
    {
        var sql = @"Select VerificationStatus From Verification
                    Inner Join GuardVerification On Verification.Id = GuarVerification.VerificationId 
                    Where 
                        GuardVerification.UserId = @UserId
                    And
                        Verification.VerificationStatus = @Status";

        var verificationStatus = await verificationRepository.SqlSingleAsync<VerificationStatus>(sql, param: new { UserId = query.User!.Id, VerificationStatus.Active });

        return Results.Ok(new VerificationByServiceProviderIdQuery.Response(verificationStatus));
    }
}