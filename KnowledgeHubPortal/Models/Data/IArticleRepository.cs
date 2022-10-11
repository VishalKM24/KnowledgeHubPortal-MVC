using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Models.Data
{
    public interface IArticleRepository
    {
        void submit(Article article);
        List<Article> Seach(string data);
        Article GetArticle(int id);
        void Approve(List<int> ids);
        void Reject(List<int> ids);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();


    }
}
