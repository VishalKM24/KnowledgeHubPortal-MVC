using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Hello()
        {
            ViewBag.Message = "Welcome to our Knowledge hub";
            return View();       
        }

        // If you want direct return function
        //public string Hello1()
        //{
        //    return "<h1>Welcome to our <u>Knowledge</u> Hub Portal</h1>";
        //}
    }
}