using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CustomHTMLHelpers.CustomHelpers
{
    public static class HTMLImageExtension
    {
        //Using String Builder
        public static MvcHtmlString ImageSb(this HtmlHelper htmlHelper,
            string src, string altText)
        {
            StringBuilder sb = new StringBuilder(512);

            sb.AppendFormat("<img src='{0}' alt='{1}' />", src, altText);

            //return HTML encoded string
            return MvcHtmlString.Create(sb.ToString());
        }

        //Using Tag Builder

        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src, 
            string altText, 
            string cssClass, 
            string name,
            object htmlAttrib =null)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            //Just a null check, just to avoid any space or blank 
            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                tb.AddCssClass(cssClass);
            }

            HTMLCommonExtensions.AddName(tb,name,"");
            

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrib));
            //return HTML encoded string
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));

        }

        //Overloaded versions

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            object htmlAttrib = null)
        {
            return HTMLImageExtension.Image(htmlHelper, src, altText, String.Empty, String.Empty, htmlAttrib);
        }

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttrib = null)
        {
            return HTMLImageExtension.Image(htmlHelper, src, altText, cssClass, String.Empty, htmlAttrib);
        }
    }
}