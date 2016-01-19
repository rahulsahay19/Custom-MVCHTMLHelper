using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHTMLHelpers.CustomHelpers
{
    public static class HTMLButtonExtension
    {
        public static MvcHtmlString BootstrapButton(
            this HtmlHelper htmlHelper,
            string innerHTML)
        {
            TagBuilder tb = new TagBuilder("button");

            //Adding CSS class in the reverse order as last one will attach first
            tb.AddCssClass("btn-primary");
            tb.AddCssClass("btn");

            tb.InnerHtml = innerHTML;

            //Button Type is of submit
            tb.MergeAttribute("type","submit");

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}