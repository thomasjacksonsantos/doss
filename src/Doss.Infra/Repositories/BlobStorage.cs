using Azure.Storage.Blobs;
using Doss.Core.Domain.Settings;
using Doss.Core.Services;
using Doss.Infra.Seedwork;

namespace Doss.Infra.Repositories;

public class BlobStorage : IBlobStorage
{
    private readonly AppSettings appSettings;
    public BlobStorage(AppSettings appSettings)
        => this.appSettings = appSettings;

    public async Task<byte[]> DownloadAsync(string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var blobContainerClient = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);

        var blob = blobContainerClient.GetBlobClient(filename);
        var content = await blob.DownloadContentAsync();

        return content.Value.Content.ToArray();
    }

    public async Task SendAudio(string fileBase64, string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var container = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);

        using (var ms = new MemoryStream(Convert.FromBase64String(fileBase64)))
            await container.UploadBlobAsync(filename, ms);
    }

    public async Task SendImage(string fileBase64, string filename)
    {
        var client = new BlobServiceClient(appSettings.BlobStorage.BlobStorageConnectionString);
        var container = client.GetBlobContainerClient(appSettings.BlobStorage.ContainerName);

        var file = Convert.FromBase64String(fileBase64)
                          .ConvertToJpeg();
        
        await container.DeleteBlobIfExistsAsync(filename);

        using (var ms = new MemoryStream(file))
            await container.UploadBlobAsync(filename, ms);
    }
}