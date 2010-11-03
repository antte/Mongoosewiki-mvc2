using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Web.Mvc;
namespace MvcApplication3.Models
{
    public class Article
    {

        public int Id { get; set;}
        public string Title { get; set;}
        public string Body { get; set;}

        private ObjectSet<Articles> articleEntities = new WikiDb().Articles;

        public Article() { }

        public Article(String title)
        {
            this.setByTitle(title);
        }

        /**
         * Create article from a Articles db object (ADO entity) (don't know if that's the correct terminology)
         * @param name="article" we run First on article, only one expected
         */
        private Article(Articles article)
        {
            try
            {
                this.Id = article.Id;
                this.Title = article.Title;
                this.Body = article.Body;

            }
            catch (Exception)
            {

            }
        }

        public string getBodyToHTML()
        {
            return new ArticleTranslator().translateAllPatterns(this.Body);
        }

        /*
         * Create a new Article from the FormCollection data
         */
        public Article(FormCollection collection)
        {
            this.Id = -1;
            this.Title = collection["Title"];
            this.Body = collection["Body"];
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
                this.Body = articles.First().Body;
            }
            catch (Exception)
            {
                throw new ArticleDoesNotExistException();
            }

        }


        internal static List<Article> Search(string q)
        {

            IQueryable<Articles> articlesDBOByTitle =   from a in new WikiDb().Articles
                                                        where a.Title.Contains(q)
                                                        select a;
            IQueryable<Articles> articlesDBOByBody =    from a in new WikiDb().Articles
                                                        where a.Body.Contains(q)
                                                        select a;

            List<Article> articles = new List<Article>();

            // Add all articles found by title to the return value
            foreach (Articles articleDBO in articlesDBOByTitle) 
            {
                articles.Add(new Article(articleDBO));
            }

            //Only add articles found by body if they dont already exist
            foreach (Articles articleDBO in articlesDBOByBody)
            {
                Boolean DBOAlreadyInArticles = false;
                foreach (Article article in articles)
                {
                    if (article.Title == articleDBO.Title)
                    {
                        DBOAlreadyInArticles = true;
                    }
                }

                if (!DBOAlreadyInArticles)
                {
                    articles.Add(new Article(articleDBO));
                }

            }

            return articles;

        }
    }
}