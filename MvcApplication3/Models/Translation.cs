using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace MvcApplication3.Models
{
    public class Translation
    {
        protected String needle;
        protected String replacement;

        public Translation(String pNeedle, String pReplacement)
        {
            this.needle = pNeedle;
            this.replacement = pReplacement;
        }

        public Translation()
        {

        }

        public String translate(String pArticleBody)
        {
            //return pArticleBody;
            //Regex r = new Regex(this.needle, RegexOptions.None);
            //pArticleBody = HttpUtility.HtmlEncode(pArticleBody);
            String newArticleBody = Regex.Replace(pArticleBody,this.needle, this.replacement);
            //newArticleBody = HttpUtility.HtmlEncode("&lt;");

            return newArticleBody;

        }

    }
}