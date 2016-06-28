using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rEX
{
    /// <summary>
    /// Custom Route Handler Example
    /// </summary>
    public class RDRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url.AbsolutePath == "/rd")
            {
                requestContext.RouteData.Values["controller"] = "rd"; // rdController is the class name
                requestContext.RouteData.Values["action"] = "about";
            }

            return new MvcHandler(requestContext);
        }
    }

}