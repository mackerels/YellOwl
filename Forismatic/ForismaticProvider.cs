using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using YellOwl.Abstractions.Provider;

namespace Forismatic
{
    public class ForismaticProvider : ITextProvider
    {
        private const string Url = "http://api.forismatic.com/api/1.0/?method=getQuote&format=json";
        private readonly HttpClient _client;

        public ForismaticProvider()
        {
            _client = new HttpClient();
        }

        public async Task<string> Provide()
        {
            var response = await _client.GetAsync(Url);
            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
            return (string)json["quoteText"];
        }
    }
}