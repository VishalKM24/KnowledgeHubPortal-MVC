using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KnowledgeHubPortal.Models.Data
{
    public class CatagoriesRepository : ICatagoriesRepository
    {
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        public void Create(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            db.SaveChanges();
        }

        public async Task CreateAsync(Catagory catagory)
        {
            db.Catagories.Add(catagory);
            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            db.Catagories.Remove(db.Catagories.Find(id));
            db.SaveChanges();
        }

        public List<Catagory> GetCatagories()
        {
            return db.Catagories.ToList();
        }

        public Catagory GetCatagory(int id)
        {
            return db.Catagories.Find(id);
        }

        public List<Catagory> SearchCatagories(string data)
        {
            return (from c in db.Catagories where c.Name.Contains(data) || c.Description.Contains(data) select c).ToList();
        }

        public void Update(Catagory catagory)
        {
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}