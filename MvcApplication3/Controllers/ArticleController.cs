using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;

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

        //
        // GET: /Article/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Article/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
