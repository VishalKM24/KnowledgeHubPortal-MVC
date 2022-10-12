using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [OutputCache(Duration = 20)]
        public ActionResult Index()
        {
            ViewBag.ToDay = DateTime.Now.ToLongTimeString();

            return View();
        }

        public ActionResult Hello()
        {
            int a = 10, b = 0;
            int c = a/b;


            return View();
        }
    }
}