using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Files;

public class DownloadFilesQuery : Query<DownloadFilesQuery.Response>
{
    public string Filename { get; set; }
    public DownloadFilesQuery(string filename)
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