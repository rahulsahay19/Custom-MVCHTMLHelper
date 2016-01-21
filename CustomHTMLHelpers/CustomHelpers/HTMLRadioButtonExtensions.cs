using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace CustomHTMLHelpers.CustomHelpers
{
    public static class HTMLRadioButtonExtensions
    {
        public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string text,
            string title,
            bool isAutoFocus,
            bool useInline,
            object htmlAttrib = null)
        {
            StringBuilder sb = new StringBuilder(512);

            RouteValueDictionary routeValueDictionary = null;

            routeValueDictionary = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrib));

            if (!string.IsNullOrWhiteSpace(title))
            {
                title = text;
            }

            routeValueDictionary.Add("title", title);

            if (isAutoFocus)
            {
                routeValueDictionary.Add("autofocus", "autofocus");
            }

            //Open the RadioButton
            if (useInline)
            {
                sb.Append("<label class='radio-inline'>");
            }
            else
            {
                sb.Append("<div class='radio'>");
                sb.Append("<label>");
            }


            //Building the RadioButton using Input Extension
            sb.Append(InputExtensions.RadioButtonFor(htmlHelper, expression, routeValueDictionary));

            //Adding text
            sb.Append(text);

            //Closing labels
            if (useInline)
            {
                sb.Append("</label>");
            }
            else
            {
                sb.Append("</label>");
                sb.Append("</div>");
            }


            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string text,
            object htmlAttrib = null)
        {
            return HTMLRadioButtonExtensions.BootstrapRadioButtonFor(htmlHelper, expression, text, String.Empty, false, false,
                null);
        }

        public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string text,
            string title,
            bool isAutoFocus,
            object htmlAttrib = null)
        {
            return HTMLRadioButtonExtensions.BootstrapRadioButtonFor(htmlHelper, expression, text, title, isAutoFocus, false,
                null);
        }
    }
}