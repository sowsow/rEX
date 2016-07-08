using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rEX.CustomHtmlHelpers
{
    // Extension Method of HtmlHelper
    public static class HtmlHelpers
    {

        public static MvcHtmlString OptionalTextHelpers(this HtmlHelper helper,
            String text,
            String format="{0}",
            String alternateText="N/A",
            String alternateFormat="{0}")
        {
            var actualText = text;
            var actualFormat = format;

            if (String.IsNullOrEmpty(actualText))
            {
                actualText = alternateText;
                actualFormat = alternateFormat;
            }

            return MvcHtmlString.Create(String.Format(actualFormat, actualText));
        }



    }


}