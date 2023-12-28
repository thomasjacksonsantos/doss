namespace Doss.Core.Domain.Settings;

public class AppSettings
{
    public Cep Cep { get; set; } = new Cep();
    public WhatsApp WhatsApp { get; set; } = new WhatsApp();
    public BlobStorage BlobStorage { get; set; }
}

public class Cep
{
    public string ServiceName { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}

public class WhatsApp
{
    public string AccountSid { get; set; } = string.Empty;
    public string AuthToken { get; set; } = string.Empty;
    public string NumberPhone { get; set; } = string.Empty;
}

public class BlobStorage
{
    public string BlobStorageConnectionString { get; set; }
    public string ContainerName { get; set; }
    public int ThumbnailWidth { get; set; }
    public string ThumbnailContainerName { get; set; }    
}