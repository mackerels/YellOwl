using Microsoft.Owin.Hosting;

namespace YellOwl
{
    public class YellOwlHost
    {
        private readonly string _url;

        public YellOwlHost(string url)
        {
            _url = url;
        }
        public void Start()
        {
            WebApp.Start<Startup>(_url);
        }
    }
}