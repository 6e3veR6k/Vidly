using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //custom route config, we must put this route before default route
            //from most specific to more generic
            //issues: if you want to change action method in the controller you should 
            //make changes in the route config, that can be more comlicated in large applications
            /*
            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults: new {controller = "Movies", action = "ByRelesedDate"},
                constraints: new { year = @"\d{4}", month = @"\d{2}"}
                );
            */
            
            //default route config
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
