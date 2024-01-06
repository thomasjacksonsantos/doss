namespace Doss.Core.Services;

public interface IBlobStorage
{
    Task SendImage(string fileBase64, string filename);

    Task SendAudio(string fileBase64, string filename);
}