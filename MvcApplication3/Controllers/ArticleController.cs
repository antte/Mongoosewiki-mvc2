using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using System.Data.Objects;

namespace MvcApplication3.Controllers
{
    public class ArticleController : Controller
    {

        //
        // GET: /Article/

        public ActionResult Index()
        {
            return View();
        }
         
        //
        // GET: /Article/Details/5

        public ActionResult Details(String title)
        {
            return View(new Article(title));
        }

        public ActionResult Create(FormCollection collection)
        {/*
            try
            {*/

                WikiDb WikiDb = new WikiDb();
                
                
                return View();
                //return RedirectToAction("View");
                /*
            }
            catch (Exception e)
            {
                e.
            }*/
        }

        //
        // POST: /Article/Search

        [HttpPost]
        public ActionResult SearchResults(FormCollection collection)
        {
            String q = collection.GetValue("q").AttemptedValue;
            ViewData["q"] = q;
            ViewData["articles"] = new List<Article>();
            List<Article> articlesFound = Article.Search(q);
            if (articlesFound.Count != 0)
            {
                ViewData["articles"] = articlesFound;
            }
            return View();
        }

        //
        // GET: /Article/Search

        public ActionResult Search()
        {
            return View();
        }
        
        //
        // GET: /Article/Edit/5
 
        public ActionResult Edit(string title)
        {
            return View(new Article(title));
        }

        // Edit frågar om inte create kan skapa en artikel om den inte redan finns
        // POST: /Article/Edit/5

        [HttpPost]
        public ActionResult Edit(string title, FormCollection collection)
        {

            Article article = null;
            ViewData["success"] = false;
            WikiDb WikiDb = new WikiDb();
            
            //If we cant check session or session username isnt set, this user cannot edit article
            try {
                if (Session["username"] == null) {
                    ViewData["error_message"] = "You have to be logged in to edit an article.";
                    return View(new Article(title));
                }
            } catch {
                ViewData["error_message"] = "You have to be logged in to edit an article.";
                return View(new Article(title));
            }

            try
            {
                article = new Article(title);
            }
            catch (ArticleDoesNotExistException)
            {
                try
                {
                    
                    //Articles newArticle = new Articles { Title = collection["Title"], Body = collection["Body"] };
                    Articles newArticle = new Articles();
                    newArticle.Title = collection["Title"];
                    newArticle.Body = collection["Body"];
                    WikiDb.AddToArticles(newArticle);
                    WikiDb.SaveChanges();
                    
                    //ViewData["debug"] += collection["Id"];
                    RedirectToAction("Details/" + title);
                }
                catch (Exception)
                {
                    ViewData["debug"] += "article doesnt exist and cant redirect";
                    return View(new Article());
                }
            }

            if (article == null)
            {
                return View(new Article());
            }

            UpdateModel(WikiDb.Articles.Single(a => a.Id == article.Id), collection.ToValueProvider());
            WikiDb.SaveChanges();
            ViewData["success"] = true;

            return View(new Article(title));

        }

        //
        // GET: /Article/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Article/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
