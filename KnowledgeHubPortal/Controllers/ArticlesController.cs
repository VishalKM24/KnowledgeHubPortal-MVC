using KnowledgeHubPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnowledgeHubPortal.Models.Entity;

namespace KnowledgeHubPortal.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticleRepository repo = new ArticleRepository();
        private ICatagoriesRepository catagoryRepo = new CatagoriesRepository();

        // GET: Articles
        // [Authorize]
        public ActionResult Index(string data = null)
        {
            // Fetch articles for browse
            List<Article> articles = new List<Article>();

            if (data == null)
                articles = repo.GetArticlesForBrowse();
            else
                articles = (from a in repo.GetArticlesForBrowse()
                            where a.Title.ToLower().Contains(data) ||
                           a.Description.ToLower().Contains(data) || a.catagory.Name.ToLower().Contains(data) ||
                           a.catagory.Description.ToLower().Contains(data)
                            select a).ToList();
            return View(articles);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Submit()
        {
            var catagories = from c in catagoryRepo.GetCatagories() select new SelectListItem { Text = c.Name, Value = c.CatagoryId.ToString()};
            ViewBag.CatagoryID = catagories;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Submit(Article article)
        {
            if(!ModelState.IsValid)
                return View();

            article.IsApproved = false;
            article.DateSubmitted = DateTime.Now;
            article.PostedBy = User.Identity.Name;

            repo.submit(article);
            TempData["Message"] = $"Article {article.Title} submitted Successfully and modified to administrator for review";

            //TODO: Send email notification to Administrator


            return RedirectToAction("Submit");
        }

        [ChildActionOnly]
        public ActionResult CatagoryHyperlink()
        {
            var catagories = catagoryRepo.GetCatagories();
            return PartialView(catagories);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Review()
        {
            var articlesForReview = repo.GetArticlesForReview();
            return View(articlesForReview);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Approve(List<int> articleIds)
        {
            repo.Approve(articleIds);
            TempData["Message"] = $"{articleIds.Count} Articles Approved.";
            //TODO: Send mail notification to article author
            return RedirectToAction("Review");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Reject(List<int> articleIds)
        {
            repo.Reject(articleIds);
            TempData["Message"] = $"{articleIds.Count} Articles Rejected";
            // TODO: Send Mail notification to article author
            return RedirectToAction("Review");
        }
    }
}