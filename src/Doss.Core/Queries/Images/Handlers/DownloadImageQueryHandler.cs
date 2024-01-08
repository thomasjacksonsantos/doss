using Doss.Core.Interfaces.Repositories;
using Doss.Core.Queries.Images;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using MediatR;

namespace Doss.Core.Queries.Residentials.Handlers;

public class DownloadImageQueryHandler : IRequestHandler<DownloadImageQuery, Result<DownloadImageQuery.Response>>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;

    public DownloadImageQueryHandler(IResidentialRepository residentialRepository,
                                     IBlobStorage blobStorage)
        => (this.residentialRepository, this.blobStorage) = (residentialRepository, blobStorage);

    public async Task<Result<DownloadImageQuery.Response>> Handle(DownloadImageQuery query, CancellationToken cancellationToken)
    {
        var files = await blobStorage.DownloadAsync(query.Filename);
        return Results.Ok(new DownloadImageQuery.Response(files));
    }
}