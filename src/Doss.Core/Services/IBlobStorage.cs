namespace Doss.Core.Services;

public interface IBlobStorage
{
    Task Upload(Stream file, string filename);
}