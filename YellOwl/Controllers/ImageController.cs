using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using YellOwl.Utility;

namespace YellOwl.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetImage(int id)
        {
            var img = new Bitmap(200, 200);
            return this.Image(img);
        }

        [HttpPost]
        [Route]
        public IHttpActionResult Upload()
        {
            return Ok();
        }
    }
}