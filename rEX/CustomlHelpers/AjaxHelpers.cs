using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace rEX.CustomlHelpers
{
    // Extension Method of AjaxHelper
    public static class AjaxHelpers
    {

        public static string ImageActionLink(this AjaxHelper ajaxHelper,
            String imageUrl,
            String imgAltText,
            String imgStyle,
            String actionName,
            String controllerName,
            Object routeValues,
            AjaxOptions ajaxOptions,
            Object htmlAttributes)
        {
            const String tag = "[xxx]"; // Arbitrary string

            // ActionLink HTML-encodes everything, there is no images only text of the URL
            String markup = ajaxHelper.ActionLink(
                tag, actionName, controllerName, routeValues, ajaxOptions, 
                htmlAttributes).ToString();

            // Replace text with IMG markup
            var urlHelper = new UrlHelper(ajaxHelper.ViewContext.RequestContext);
            var img = String.Format(
                "<img src='{0}' alt='{1}' title='{1}' style='{2}' />",
                urlHelper.Content(imageUrl),
                imgAltText,
                imgStyle);

            var modifiedMarkup = markup.Replace(tag, img);
            return modifiedMarkup;
        }

    }

}