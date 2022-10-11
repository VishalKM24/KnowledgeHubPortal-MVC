using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Models.Entity;

namespace KnowledgeHubPortal.Models.Data
{
    public interface ICatagoriesRepository
    {
        void Create(Catagory catagory);
        void Update(Catagory catagory);
        Catagory GetCatagory(int id);
        List<Catagory> GetCatagories();
        List<Catagory> SearchCatagories(string data);
        void Delete(int id);
    }
}
