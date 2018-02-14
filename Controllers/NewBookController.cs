using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewMVC2018_VersionB.Models;

namespace BookReviewMVC2018_VersionB.Controllers
{
    public class NewBookController : Controller
    {
        BookReviewDbEntities db = new BookReviewDbEntities();
        // GET: NewBook
        public ActionResult Index()
        {
            if (Session["reviewKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "Must be logged in to enter Books";
                return RedirectToAction("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Title, ISBN, AuthorName")]NewBook nb)
        {
            Author a = new Author();
            a.AuthorName = nb.AuthorName;
            db.Authors.Add(a);
            db.SaveChanges();

            //for donation, get the user key from the session
            Book b = new Book();
            b.BookTitle = nb.Title;
            b.BookISBN = nb.ISBN;
            b.BookEntryDate = DateTime.Now;
            Author author = db.Authors.FirstOrDefault(x => x.AuthorName == nb.AuthorName);
            b.Authors.Add(author);

            db.Books.Add(b);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Thank you, the book has been added";

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}