using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rEX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = true;

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "rd", action = "Index", id = UrlParameter.Optional }
            );

            /*
            routes.MapRoute(
                name: "ProductInfo",
                url: "{controller}/{productId}/{locale}",
                defaults: new { controller = "Product", action = "Index", locale = "en-us"},
                constraints: new { productId = @"\d[8]", locale = "[a-z]{2}-[a-z]{2}" }
            );
            */

            // Register Custom Route Handler
            Route rdRoute = new Route("RD", new RDRouteHandler());
            routes.Add("RDRoute", rdRoute);

            routes.MapRoute(
                name: "RDEchoRoute",
                url: "{controller}/{action}/data",
                defaults: new { controller = "RD", action = "Echo", data = UrlParameter.Optional }
            );

        }
    }





}
