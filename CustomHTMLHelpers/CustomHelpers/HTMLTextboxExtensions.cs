using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Microsoft.Owin.Security.Provider;

namespace CustomHTMLHelpers.CustomHelpers
{
    public static class HTMLTextboxExtensions
    {
        //This Input extension helps a ton while dealing with anonymous value coming in during data binding
        //as this takes the expressions and return the same as MVCHTMLString
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            HTMLCommonExtensions.HTML5InputTypes html5InputTypes,
            string title,
            string placeholder,
            bool isRequired,
            bool isAutoFocus,
            string cssClass = "",
            object htmlAttribs = null)
        {
            RouteValueDictionary routeValueDictionary;

            //Creates new Route Value Dictionary here
            routeValueDictionary = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttribs));

            //Adds all other values here
            routeValueDictionary.Add("type", html5InputTypes);

            if (!string.IsNullOrWhiteSpace(title))
            {
                routeValueDictionary.Add("title", title);
            }

            if (!string.IsNullOrWhiteSpace(placeholder))
            {
                routeValueDictionary.Add("placeholder", placeholder);
            }

            if (isRequired)
            {
                routeValueDictionary.Add("required", "required");
            }

            if (isAutoFocus)
            {
                routeValueDictionary.Add("autofocus", "autofocus");
            }

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                cssClass = "form-control";
            }
            else
            {
                cssClass = "form-control " + cssClass;
            }

            routeValueDictionary.Add("class", cssClass);
            return InputExtensions.TextBoxFor(htmlHelper, expression, routeValueDictionary);
        }

        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
           this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TValue>> expression,
           HTMLCommonExtensions.HTML5InputTypes html5InputTypes,
          object htmlAttribs = null)
        {
            return HTMLTextboxExtensions.BootstrapTextBoxFor(htmlHelper, expression, html5InputTypes, String.Empty,
                String.Empty, false, false, String.Empty,
                htmlAttribs);
        }

        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          HTMLCommonExtensions.HTML5InputTypes html5InputTypes,
          string cssClass,
         object htmlAttribs = null)
        {
            return HTMLTextboxExtensions.BootstrapTextBoxFor(htmlHelper, expression, html5InputTypes,String.Empty,
                String.Empty, false, false, cssClass,
                htmlAttribs);
        }

        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            HTMLCommonExtensions.HTML5InputTypes html5InputTypes,
            string title,
            string placeholder,
            bool isRequired,
            bool isAutoFocus,
           
            object htmlAttribs = null)
        {
            return HTMLTextboxExtensions.BootstrapTextBoxFor(htmlHelper, expression, html5InputTypes,title,
                 placeholder, true, false, String.Empty,htmlAttribs);
        }
    }

}