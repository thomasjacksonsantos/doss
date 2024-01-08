using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Images;

public class DownloadImageQuery : Query<DownloadImageQuery.Response>
{
    public string Filename { get; set; }
    public DownloadImageQuery(string filename)
    {
        Filename = filename;
    }

    public class Response
    {
        public byte[] Files { get; set; }
        public Response(byte[] files)
            => Files = files;
    }
}