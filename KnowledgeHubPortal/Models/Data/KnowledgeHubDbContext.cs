using KnowledgeHubPortal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.Models.Data
{
    public class KnowledgeHubDbContext: DbContext
    {
        // Configure the db
        public KnowledgeHubDbContext() : base("name=DefaultConnection")
        {

        }
        // configure the tables

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}