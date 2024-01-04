using ImageMagick;

namespace Doss.Infra.Seedwork;

public static class ConvertImageExtentions
{
    public static byte[] ConvertToJpeg(this byte[] file)
    {
        using (var stream = new MemoryStream())
        {
            using (MagickImage magic = new MagickImage(file))
            {
                magic.Settings.Format = MagickFormat.Jpeg;
                magic.Write(stream);
                return stream.ToArray();
            }
        }
    }
}