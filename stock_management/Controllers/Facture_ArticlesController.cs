using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using stock_management.Models;

namespace stock_management.Controllers
{
    public class Facture_ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facture_Articles
        public ActionResult Index( string searchString)
        {
            //var facture_Aricles = db.Facture_Aricles.Include(f => f.Article);
            string payer = Request["payer"];
            Console.WriteLine(payer);
            var facture_Aricles = from m in db.Facture_Aricles.Include(f => f.Article)
                                  select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (payer == "payement" )
                {
                    bool pay = true;
                    facture_Aricles = facture_Aricles.Where(s => s.Name.Contains(searchString) && s.payer == pay
                                       );
                }
                else if(payer == "npayement")
                {
                    bool pay = false;
                    facture_Aricles = facture_Aricles.Where(s => s.Name.Contains(searchString) && s.payer == pay
                                       );
                }
                else
                {
                    facture_Aricles = facture_Aricles.Where(s => s.Name.Contains(searchString)
                                           );
                }
            }
            facture_Aricles = facture_Aricles.OrderBy(s => s.date_Arrivage);
            return View(facture_Aricles.ToList());
        }

        // GET: Facture_Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture_Articles facture_Articles = db.Facture_Aricles.Find(id);
            if (facture_Articles == null)
            {
                return HttpNotFound();
            }
            return View(facture_Articles);
        }

        // GET: Facture_Articles/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Aricles, "ArticleID", "Title");

            return View();
        }

        // POST: Facture_Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Facture_ArticleID,Name,category,quantite,date_Arrivage,date_Expiration,Price,payer,ArticleID")] Facture_Articles facture_Articles)
        {
            if (ModelState.IsValid)
            {
                var articles = db.Aricles.Find(facture_Articles.ArticleID);
                decimal a = articles.Unit_Price; 
                DateTime d1 = facture_Articles.date_Arrivage;
                DateTime d2 = facture_Articles.date_Expiration;
                if (0 < DateTime.Compare(d1, d2))
                {
                    ViewBag.Message = "there is wrong in the date field";
                    return RedirectToAction("Create");
                }
                facture_Articles.Price = facture_Articles.quantite * articles.Unit_Price;
                articles.quantite = articles.quantite - facture_Articles.quantite;
                db.Facture_Aricles.Add(facture_Articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Aricles, "ArticleID", "Title", "date_Arrivage", facture_Articles.ArticleID);
            return View(facture_Articles);
        }

        // GET: Facture_Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture_Articles facture_Articles = db.Facture_Aricles.Find(id);
            if (facture_Articles == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Aricles, "ArticleID", "Title", facture_Articles.ArticleID);
            return View(facture_Articles);
        }

        // POST: Facture_Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Facture_ArticleID,Name,category,quantite,date_Arrivage,date_Expiration,Price,payer,ArticleID")] Facture_Articles facture_Articles)
        {
            if (ModelState.IsValid)
            {
                DateTime d1 = facture_Articles.date_Arrivage;
                DateTime d2 = facture_Articles.date_Expiration;
                if (0 < DateTime.Compare(d1, d2))
                {
                    ViewBag.Message = "something is wrong in the date field";
                    return RedirectToAction("Edit");
                }
                db.Entry(facture_Articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Aricles, "ArticleID", "Title", facture_Articles.ArticleID);
            return View(facture_Articles);
        }

        // GET: Facture_Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture_Articles facture_Articles = db.Facture_Aricles.Find(id);
            if (facture_Articles == null)
            {
                return HttpNotFound();
            }
            return View(facture_Articles);
        }

        // POST: Facture_Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facture_Articles facture_Articles = db.Facture_Aricles.Find(id);
            db.Facture_Aricles.Remove(facture_Articles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
