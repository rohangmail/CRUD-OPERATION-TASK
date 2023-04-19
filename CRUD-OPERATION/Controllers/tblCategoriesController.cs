using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_OPERATION.Models;


namespace CRUD_OPERATION.Controllers
{
    public class tblCategoriesController : Controller
    {
        private DBModelss db = new DBModelss();

        
        public ActionResult Index()
        {
            
            var tblCategories = db.tblCategories.Include(t => t.tblProduct);
            return View(tblCategories.ToList());
           
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

        
        public ActionResult Create()
        {
            ViewBag.ProductName = new SelectList(db.tblProducts, "ProductID", "ProductName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,ProductName")] tblCategory tblCategory)
        {
            if (ModelState.IsValid)
            {
                db.tblCategories.Add(tblCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductName = new SelectList(db.tblProducts, "ProductID", "ProductName", tblCategory.ProductName);
            return View(tblCategory);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductName = new SelectList(db.tblProducts, "ProductID", "ProductName", tblCategory.ProductName);
            return View(tblCategory);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,ProductName")] tblCategory tblCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductName = new SelectList(db.tblProducts, "ProductID", "ProductName", tblCategory.ProductName);
            return View(tblCategory);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCategory tblCategory = db.tblCategories.Find(id);
            if (tblCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblCategory);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCategory tblCategory = db.tblCategories.Find(id);
            db.tblCategories.Remove(tblCategory);
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
