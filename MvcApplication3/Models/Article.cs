using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
namespace MvcApplication3.Models
{
    public class Article
    {

        public int Id { get; set;}
        public string Title { get; set;}
        public string Body { get; set;}

        private ObjectSet<Articles> articleEntities = new WikiEntities().Articles;

        public Article(String title)
        {
            this.setByTitle(title);
        }

        /*
         * Populates Article object with data from the database.
         */
        private void setByTitle(string title) { 
            var articles = from a in articleEntities
                           where a.Title == title
                           select a;
            
            try
            {
                this.Id = articles.First().Id;
                this.Title = articles.First().Title;
                ArticleTranslator t = new ArticleTranslator();
                String body = articles.First().Body;
                this.Body = t.translateAllPatterns(body);
                //this.Body = t.translate(articles.First().Body);
                //this.Body = articles.First().Body;
            }
            catch (Exception)
            {
                
            }
        }

    }
}