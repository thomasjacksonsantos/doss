using Doss.Core.Seedwork;
using Doss.Core.Services;
using MediatR;

namespace Doss.Core.Queries.Files.Handlers;

public class DownloadFilesQueryHandler : IRequestHandler<DownloadFilesQuery, Result<DownloadFilesQuery.Response>>
{
    private readonly IBlobStorage blobStorage;

    public DownloadFilesQueryHandler(IBlobStorage blobStorage)
        => this.blobStorage = blobStorage;

    public async Task<Result<DownloadFilesQuery.Response>> Handle(DownloadFilesQuery query, CancellationToken cancellationToken)
    {
        var files = await blobStorage.DownloadAsync(query.Filename);
        return Results.Ok(new DownloadFilesQuery.Response(files));
    }
}