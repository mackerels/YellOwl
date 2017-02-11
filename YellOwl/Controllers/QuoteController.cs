using System;
using System.Threading.Tasks;
using System.Web.Http;
using YellOwl.Abstractions.Provider;

namespace YellOwl.Controllers
{
    [RoutePrefix("api/quote")]
    public class QuoteController : ApiController
    {
        private readonly ITextProvider _quotes;

        public QuoteController(ITextProvider quote)
        {
            _quotes = quote;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _quotes.Provide());
        }
    }
}