using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: Microsoft.Owin.OwinStartup(typeof(ServerApi.Startup))]

namespace ServerApi
{
   public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration CONFIG = new HttpConfiguration();
            CONFIG.EnableCors();

            CONFIG.Routes.MapHttpRoute(
                name: "createUserApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            CONFIG.Formatters.JsonFormatter.SupportedMediaTypes
     .Add(new MediaTypeHeaderValue("text/html"));

            appBuilder.UseWebApi(CONFIG);
        }
    }
}
