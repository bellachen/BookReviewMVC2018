using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewMVC2018_VersionB.Models;

namespace BookReviewMVC2018_VersionB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //post and validate directives
        [HttpPost]

        [ValidateAntiForgeryToken]
        //overloaded Index method
        public ActionResult Index([Bind(Include = "UserName, Password, ReviewerKey")]LoginClass loginClass)
        {
            //make connection to Ado Entity model classes
            BookReviewDbEntities br = new BookReviewDbEntities();
            //Assign review key a value of 0
            loginClass.ReviewerKey = 0;
            //pass the values to the stored procedure and get result (-1 = failure)
            int result = br.usp_ReviewerLogin(loginClass.UserName, loginClass.Password);
            //test the results
            if (result != -1)
            {
                //run a query to get the ReviewerKey
                var ukey = (from r in br.Reviewers
                            where r.ReviewerUserName.Equals(loginClass.UserName)
                            select r.ReviewerKey).FirstOrDefault();
                loginClass.ReviewerKey = (int)ukey;
            }

            //return the class to the Result view
            return View("Result", loginClass);
        }

        public ActionResult Result(LoginClass loginClass)
        {
            return View(loginClass);
        }
    }


}