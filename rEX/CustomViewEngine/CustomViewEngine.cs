using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rEX.CustomViewEngine
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            this.MasterLocationFormats = base.MasterLocationFormats;
            this.ViewLocationFormats = new string[] 
                                       {
                                           "~/Views/{1}/{0}.cshtml"
                                       };

            // Customize the location for partial views
            this.PartialViewLocationFormats = new string[]
                                              {
                                                "~/PartialViews/{1}/{0}.cshtml",
                                                "~/PartialViews/{1}/{0}/.vbhtml"
                                              };



        }


    }

}