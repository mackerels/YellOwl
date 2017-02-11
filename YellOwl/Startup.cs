using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using YellOwl.Modules;

[assembly: OwinStartup(typeof(YellOwl.Startup))]

namespace YellOwl
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var filesystem = new PhysicalFileSystem("../frontend/wwwroot");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = filesystem
            };
            options.StaticFileOptions.FileSystem = filesystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] {"index.html"};
            app.UseFileServer(options);

            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(ConfigureWebApi());
        }


        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

//            config.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "{controller}/{id}",
//                defaults: new {id = RouteParameter.Optional}
//            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            return config;
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}