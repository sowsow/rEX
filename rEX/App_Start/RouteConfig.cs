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
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductInfo",
                url: "{controller}/{productId}/{locale}",
                defaults: new { controller = "Product", action = "Index", locale = "en-us"},
                constraints: new { productId = @"\d[8]", locale = "[a-z]{2}-[a-z]{2}" }
            );


            // Register Custom Custom Route Handler
            Route clarityRoute = new Route("clarity", new ClarityRouteHandler());
            routes.Add("ClarityRoute", clarityRoute);

        }
    }


    /// <summary>
    /// Custom Route Handler Example
    /// </summary>
    public class ClarityRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url.AbsolutePath == "/clarity")
            {
                requestContext.RouteData.Values["controller"] = "home";
                requestContext.RouteData.Values["action"] = "clarity";
            }

            return new MvcHandler(requestContext);
        }
    }



}
