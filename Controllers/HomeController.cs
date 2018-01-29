using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewMVC2018_VersionB.Models;

namespace BookReviewMVC2018_VersionB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BookReviewDbEntities db = new BookReviewDbEntities();

            return View(db.Books.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}