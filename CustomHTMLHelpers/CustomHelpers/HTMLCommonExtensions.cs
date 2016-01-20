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

        public enum HTML5InputTypes
        {
            //make sure below values matches exactly with HTML 5 inputs
            //This is to cut the additional switch statement
            text,
            color,
            date,
            datetime,
            email,
            month,
            number,
            password,
            search,
            tel,
            time,
            url,
            week
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