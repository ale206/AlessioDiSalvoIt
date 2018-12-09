using System.Web.Mvc;
using System.Web.Routing;

namespace TaechIdeas.Alessiodisalvo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{lang}/{controller}/{action}/{id}",
                new {lang = "en", controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}