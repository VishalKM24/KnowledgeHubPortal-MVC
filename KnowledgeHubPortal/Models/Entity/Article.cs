using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortal.Models.Entity
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }
        [MaxLength(500)]
        public string Description { get; set;  } 
        public int CatagoryID { get; set; }
        public virtual Catagory catagory { get; set; }
        public bool IsApproved { get; set; }
        public string PostedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}