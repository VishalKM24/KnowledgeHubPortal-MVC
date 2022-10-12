using KnowledgeHubPortal.Models.Data;
using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows;
using PagedList;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Controllers
{
    // [Authorize(Roles = "admin")]
    public class CatagoriesController : Controller
    {
        // GET: Catagories
        //.../Catagories/index
        private KnowledgeHubDbContext db = new KnowledgeHubDbContext();
        private ICatagoriesRepository repo = null; // new CatagoriesRepository();

        public CatagoriesController(ICatagoriesRepository repo)
        {
            this.repo = repo;
        }


        [AllowAnonymous]
        public ActionResult Index(string Name, int? page)
        {
            // fetch the catagories information from model/dal

            // NEED TO IMPLEMENT IN repo format
            var catagories = from m in db.Catagories select m;
            if (!string.IsNullOrEmpty(Name))
            {
                catagories = from cust in db.Catagories where cust.Name == Name || cust.Description == Name select cust;
            }
            int pageSize = 3;
            int PageNum = (page ?? 1);
            
            
            // pass the data into view
            //ViewBag.Catagories = catagories;
            //ViewData["catagories"] = catagories;
            //TempData["Catagories"] = catagories;
            
            return View(catagories.ToList().ToPagedList(PageNum, pageSize));
        }


        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Save(Catagory catagory)
        {
            // Validate
            if (!ModelState.IsValid)
                return View("Create");

            db.Catagories.Add(catagory);
            db.SaveChanges();
            TempData["Message"] = $"Catagory {catagory.Name} successfully Created";
            return RedirectToAction("Index");
        }

        // Async Method
        public async Task<ActionResult> SaveAsync(Catagory catagory)
        {
            // Validate
            if (!ModelState.IsValid)
                return View("Create");

            //db.Catagories.Add(catagory);
            //db.SaveChanges();

            await repo.CreateAsync(catagory);
            TempData["Message"] = $"Catagory {catagory.Name} successfully Created";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Are you sure to delete this item??", "Confirm Delete!!", MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                //var catagoryToDelete = db.Catagories.Find(id);
                // db.Catagories.Remove(catagoryToDelete);

                var catagoryToDelete = repo.GetCatagory(id);
                repo.Delete(id);
                // db.SaveChanges();
                TempData["Message"] = $"Catagory {catagoryToDelete.Name} Successfully Deleted";
                return RedirectToAction("Index");
            }
            else
            {
                // var catagoryToDelete = db.Catagories.Find(id);
                
                var catagoryToDelete = repo.GetCatagory(id);
                TempData["Message"] = $"Catagory {catagoryToDelete.Name} could not be deleted";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var catagoryToEdit = repo.GetCatagory(id);
            return View(catagoryToEdit);
        }


        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
                return View();

            //db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

            repo.Update(catagory);
            TempData["Message"] = $"Catagory {catagory.Name} successfully Edited";
            return RedirectToAction("Index");
        }
    }
}