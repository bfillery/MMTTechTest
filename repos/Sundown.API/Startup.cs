using System.Web.Http;

namespace Sundown.API
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
