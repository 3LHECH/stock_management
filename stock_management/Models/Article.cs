using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace stock_management.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public byte category { get; set; }
        public int quantite { get; set; }
        public uint stock { get; set; }
        public DateTime date_Arrivage { get; set; }
        public DateTime date_Expiration { get; set; }
        public decimal Unit_Price { get; set; }

        public virtual ICollection<Facture_Articles> Facture_Articles { get; set; }
    }
}