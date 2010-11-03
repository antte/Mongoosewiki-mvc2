using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Models
{
    public class ArticleTranslator
    {
        List<Translation> translations = new List<Translation>();

        public ArticleTranslator()
        {

            
            translations.Add(new Translation(@"\[section\]", "<p>"));
            translations.Add(new Translation(@"\[/section\]", "</p>"));
            translations.Add(new Translation(@"\[b\]", "<strong>"));
            translations.Add(new Translation(@"\[/b\]", "</strong>"));
            translations.Add(new Translation(@"\[i\]", "<em>"));
            translations.Add(new Translation(@"\[/i\]", "</em>"));
            translations.Add(new Translation(@"\[\*\]", "\n<li>"));
            translations.Add(new Translation(@"\[/\*\]", "</li>"));
            translations.Add(new Translation(@"===(.+)===", "<h2>$1</h2>"));
            translations.Add(new Translation(@"==(.+)==", "<h3>$1</h3>"));
            //translations.Add(new Translation(@"[\b\t]\*[\b\t]([^\n]+)", "\n<li>$1</li>"));
            translations.Add(new Translation(@"\[\[(\w+)\]\]", "<a href='/Article/Details/$1'>$1</a>"));
            translations.Add(new Translation(@"\[([^\b]+)\b([^\[\b]+)\]", "<a href=\'$1\'>$2</a>"));
            
        }

        public String translateAllPatterns(String articleBody) {
            
		    foreach (Translation translation in translations) {
			    articleBody = translation.translate(articleBody);
                
		    }
		
		    return articleBody;
		
	    }
    }
}