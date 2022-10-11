using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.Models.Data
{

    public class ArticleRepository : IArticleRepository
    {
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        public void Approve(List<int> articleIds)
        {
            // TODO: Need to improve the solution
            foreach (var id in articleIds)
            {
                var article = db.Articles.Find(id);
                if (article != null)
                    article.IsApproved = true;
            }
            db.SaveChanges();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            return db.Articles.Where(a => !a.IsApproved).ToList();
        }

        public void Reject(List<int> articleIds)
        {
            foreach (var id in articleIds)
            {
                var article = db.Articles.Find(id);
                if (article != null)
                    db.Articles.Remove(article);
            }
            db.SaveChanges();
        }

        public List<Article> Seach(string data)
        {
            throw new NotImplementedException();
        }

        public void submit(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
    }
}