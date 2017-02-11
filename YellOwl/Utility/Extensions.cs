using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace YellOwl.Utility
{
    public static class Extensions
    {
        public static HttpResponseMessage File(this ApiController controller, Stream stream, string mime)
        {
            var result = new HttpResponseMessage {Content = new StreamContent(stream)};
            result.Content.Headers.ContentType = new MediaTypeHeaderValue(mime);
            return result;
        }

        public static HttpResponseMessage Image(this ApiController controller, Image image)
        {
            return controller.File(image.ToStream(), "image/jpeg");
        }

        public static HttpResponseMessage Image(this ApiController controller, Stream stream)
        {
            return controller.File(stream, "image/jpeg");
        }

        public static Stream ToStream(this Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            return ms;
        }

        public static byte[] ToBytes(this Image img)
        {
            return ((MemoryStream) img.ToStream()).ToArray();
        }
    }
}