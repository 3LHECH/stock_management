using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace stock_management.Models
{
    public class Facture_Articles
    {
        [Key]
        public int Facture_ArticleID { get; set; }
        public string Name { get; set; }
        public byte category { get; set; }
        public int quantite { get; set; }
        public DateTime date_Arrivage { get; set; }
        public DateTime date_Expiration { get; set; }
        public decimal Price { get; set; }
        public bool payer { get; set; }
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
    }
}