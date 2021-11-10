using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OperaWebSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login", 
                url: "{controller}/{action}/{name}/{role}",
                defaults: new {controller = "Test", action = "Login"}
                ); 

            routes.MapRoute(
                name: "SearchByTitle",
                url: "{controller}/{action}/{title}",
                defaults: new { controller = "Test", action = "SearchByTitle" }
                );

            routes.MapRoute(
                name: "Detail",
                url: "{controller}/Detail/{id}",
                defaults: new { controller = "Opera", action = "Detail" }
            );
            routes.MapRoute(
             name: "Delete",
             url: "{controller}/Delete/{id}",
             defaults: new { controller = "Opera", action = "Delete", id = UrlParameter.Optional }
             );
            routes.MapRoute(
            name: "Edit",
            url: "{controller}/Edit/{id}",
            defaults: new { controller = "Opera", action = "Edit", id = UrlParameter.Optional }
            );
        }
    }
}
