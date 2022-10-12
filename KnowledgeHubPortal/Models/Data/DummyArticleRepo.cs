using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.Models.Data
{
    public class DummyArticleRepo : IArticleRepository
    {
        public void Approve(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesForBrowse()
        {
            List<Article> articles = new List<Article>()
            {
                new Article { ArticleId = 111, Title = "dummy1", URL = "dummyurl1"},
                new Article { ArticleId = 222, Title = "dummy2", URL = "dummyurl2"},
                new Article { ArticleId = 333, Title = "dummy3", URL = "dummyurl3"},
                new Article { ArticleId = 444, Title = "dummy4", URL = "dummyurl4"},

            };

            return articles;
        }

        public List<Article> GetArticlesForReview()
        {
            throw new NotImplementedException();
        }

        public void Reject(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<Article> Seach(string data)
        {
            throw new NotImplementedException();
        }

        public void submit(Article article)
        {
            throw new NotImplementedException();
        }
    }
}