using Azure.Storage.Blobs;
using Doss.Core.Domain.Settings;
using Doss.Core.Services;
using Microsoft.Extensions.Options;
using Doss.Infra.Seedwork;

namespace Doss.Infra.Repositories;

public class BlobStorage : IBlobStorage
{
    private readonly AppSettings appSettings;
    public BlobStorage(IOptions<AppSettings> appSettings)
        => (this.appSettings) = (appSettings.Value);

    public async Task SendAudio(string fileBase64, string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var container = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);

        using (var ms = new MemoryStream(Convert.FromBase64String(fileBase64)))
        {
            await container.UploadBlobAsync(filename, ms);
        }
    }

    public async Task SendImage(string fileBase64, string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var container = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);

        var file = Convert.FromBase64String(fileBase64)
                          .ConvertToJpeg();

        using (var ms = new MemoryStream(file))
        {
            await container.UploadBlobAsync(filename, ms);
        }
    }
}