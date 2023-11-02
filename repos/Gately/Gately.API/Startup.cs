using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;

namespace Gately.API
{
    public class Startup
    {
        private HttpConfiguration configureWebAPI()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute
            (
                name: "defaultCorrective",
                routeTemplate: "api/{controller}/{Action}/"
            );

            config.Routes.MapHttpRoute
            (
                name: "default",
                routeTemplate: "api/{controller}"
            );
            config.MapHttpAttributeRoutes();

            return config;
        }
    }
}