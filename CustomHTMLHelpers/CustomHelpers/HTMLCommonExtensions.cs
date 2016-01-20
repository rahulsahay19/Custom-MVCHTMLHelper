using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomHTMLHelpers.CustomHelpers
{
    public static class HTMLCommonExtensions
    {
        public enum HTMLButtonTypes
        {
            submit,
            button,
            reset
        }
        public static void AddName(TagBuilder tb, string name, string id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name);

                if (string.IsNullOrWhiteSpace(id))
                {
                    tb.GenerateId(name);
                }
                else
                {
                    tb.MergeAttribute("id",TagBuilder.CreateSanitizedId(id));
                }
             }
            tb.MergeAttribute("name", name);
        }
    }
}