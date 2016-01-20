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
            string innerHTML,
            string cssClass,
            string name,
            string title,
            bool isFormNoValidate=false,
            bool isAutoFocus =false,
            HTMLCommonExtensions.HTMLButtonTypes buttonTypes = HTMLCommonExtensions.HTMLButtonTypes.submit,
            string MovieReviewAction ="",
            object htmlAttribs=null)
        {
            TagBuilder tb = new TagBuilder("button");

            //Below Piece of code commented, just to take effect of other button css classes
          /*  if (!string.IsNullOrWhiteSpace(cssClass))
            {
                //Check for bootstrap stuff say btn-
                if (!cssClass.Contains("btn-"))
                {
                    cssClass = "btn-primary" + cssClass;
                }
                else
                {
                    cssClass = "btn-primary";
                }
            }*/

            //Adding CSS class in the reverse order as last one will attach first
            tb.AddCssClass(cssClass);
            tb.AddCssClass("btn");

            //Added HTML 5 Attributes

            if (!string.IsNullOrWhiteSpace(MovieReviewAction))
            {
                tb.MergeAttribute("data-movie-review-action",MovieReviewAction);
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                tb.MergeAttribute("title",title);
            }

            if (isFormNoValidate)
            {
                tb.MergeAttribute("formnovalidate", "formnovalidate");
            }

            if (isAutoFocus)
            {
                tb.MergeAttribute("autofocus", "autofocus");
            }

            //Added HTML 5 Attributes - End
            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttribs));
            HTMLCommonExtensions.AddName(tb, name, "");
            tb.InnerHtml = innerHTML;

            //Switch statement to identify different button type
            switch(buttonTypes)
            {
                case HTMLCommonExtensions.HTMLButtonTypes.submit:
                    tb.MergeAttribute("type", "submit");
                    break;
                case HTMLCommonExtensions.HTMLButtonTypes.button:
                    tb.MergeAttribute("type", "button");
                    break;
                case HTMLCommonExtensions.HTMLButtonTypes.reset:
                    tb.MergeAttribute("type", "reset");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buttonTypes), buttonTypes, null);
            }

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}