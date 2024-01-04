namespace Doss.Core.Services;

public interface IBlobStorage
{
    Task Upload(string fileBase64, string filename);
}