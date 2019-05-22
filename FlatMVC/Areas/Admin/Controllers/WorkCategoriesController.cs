using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;

namespace FlatMVC.Areas.Admin.Controllers
{
    public class WorkCategoriesController : Controller
    {
        private FlatContext db = new FlatContext();

        // GET: Admin/WorkCategories
        public ActionResult Index()
        {
            return View(db.WorkCategories.ToList());
        }

        // GET: Admin/WorkCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCategory workCategory = db.WorkCategories.Find(id);
            if (workCategory == null)
            {
                return HttpNotFound();
            }
            return View(workCategory);
        }

        // GET: Admin/WorkCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WorkCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WorkCategory workCategory)
        {
            if (ModelState.IsValid)
            {
                db.WorkCategories.Add(workCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workCategory);
        }

        // GET: Admin/WorkCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCategory workCategory = db.WorkCategories.Find(id);
            if (workCategory == null)
            {
                return HttpNotFound();
            }
            return View(workCategory);
        }

        // POST: Admin/WorkCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WorkCategory workCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workCategory);
        }

        // GET: Admin/WorkCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkCategory workCategory = db.WorkCategories.Find(id);
            if (workCategory == null)
            {
                return HttpNotFound();
            }
            return View(workCategory);
        }

        // POST: Admin/WorkCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkCategory workCategory = db.WorkCategories.Find(id);
            db.WorkCategories.Remove(workCategory);
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
