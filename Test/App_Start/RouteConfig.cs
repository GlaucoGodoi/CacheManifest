using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Test
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("cache.manifest", "cache.manifest/{empty}", new { controller = "Home", action = "Manifest", empty = UrlParameter.Optional });
            //To handle the dots in url of cache.manifest you'll need to add the following handler in web.config
            //Under system.webServer/handlers
            //< add name = "UrlRoutingHandler"
            //type = "System.Web.Routing.UrlRoutingHandler, 
            //System.Web, Version = 4.0.0.0, 
            //Culture = neutral, 
            //PublicKeyToken = b03f5f7f11d50a3a"
            //path = "/cache.manifest/*"
            //verb = "GET" />

            //By the way: the paths and filenames you'll register in the manifest are case sensitive.

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
