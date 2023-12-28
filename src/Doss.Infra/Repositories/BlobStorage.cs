using Azure.Storage.Blobs;
using Doss.Core.Domain.Settings;
using Doss.Core.Services;
using Microsoft.Extensions.Options;

namespace Doss.Infra.Repositories;

public class BlobStorage : IBlobStorage
{
    private readonly AppSettings appSettings;
    public BlobStorage(IOptions<AppSettings> appSettings)
        => (this.appSettings) = (appSettings.Value);

    public async Task Upload(Stream file, string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var container = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);
        await container.UploadBlobAsync(filename, file);
    }
}