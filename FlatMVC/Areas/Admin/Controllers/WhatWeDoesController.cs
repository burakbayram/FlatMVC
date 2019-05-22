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
    public class WhatWeDoesController : Controller
    {
        private FlatContext db = new FlatContext();

        // GET: Admin/WhatWeDoes
        public ActionResult Index()
        {
            return View(db.WhatWeDos.ToList());
        }

        // GET: Admin/WhatWeDoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatWeDo whatWeDo = db.WhatWeDos.Find(id);
            if (whatWeDo == null)
            {
                return HttpNotFound();
            }
            return View(whatWeDo);
        }

        // GET: Admin/WhatWeDoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhatWeDoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,ImageURL")] WhatWeDo whatWeDo)
        {
            if (ModelState.IsValid)
            {
                db.WhatWeDos.Add(whatWeDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whatWeDo);
        }

        // GET: Admin/WhatWeDoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatWeDo whatWeDo = db.WhatWeDos.Find(id);
            if (whatWeDo == null)
            {
                return HttpNotFound();
            }
            return View(whatWeDo);
        }

        // POST: Admin/WhatWeDoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,ImageURL")] WhatWeDo whatWeDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whatWeDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whatWeDo);
        }

        // GET: Admin/WhatWeDoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatWeDo whatWeDo = db.WhatWeDos.Find(id);
            if (whatWeDo == null)
            {
                return HttpNotFound();
            }
            return View(whatWeDo);
        }

        // POST: Admin/WhatWeDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhatWeDo whatWeDo = db.WhatWeDos.Find(id);
            db.WhatWeDos.Remove(whatWeDo);
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
