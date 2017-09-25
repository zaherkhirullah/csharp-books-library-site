using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZHYR_Library.Areas.Admin.Controllers;

namespace ZHYR_Library
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] { typeof(UserController).Namespace };
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" }, namespaces);
            routes.MapRoute(name: "User", url: "User/Profile", defaults: new { controller = "User", action = "Index" ,area="Admin"}, namespaces: namespaces);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = /*UrlParameter.Optional*/"" }
            );
        }
    }
}
