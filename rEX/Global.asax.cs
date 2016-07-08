﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace rEX
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /* Configuration of Using Custom View Engine */
            // Remove default engines and adds the new one
            /*  e.g.
                ViewEngines.Engines.Clear();
                ViewEngines.Engines.Add(new CustomViewEngine.CustomViewEngine());
            */



        }
    }
}
