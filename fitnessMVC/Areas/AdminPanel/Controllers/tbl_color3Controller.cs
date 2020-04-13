using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fitnessMVC.Model;

namespace fitnessMVC.Areas.AdminPanel.Controllers
{
    public class tbl_color3Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_color3
        public ActionResult Index()
        {
            return View(db.tbl_color3.ToList());
        }

        // GET: AdminPanel/tbl_color3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color3 tbl_color3 = db.tbl_color3.Find(id);
            if (tbl_color3 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color3);
        }

        // GET: AdminPanel/tbl_color3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_color3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description")] tbl_color3 tbl_color3)
        {
            if (ModelState.IsValid)
            {
                db.tbl_color3.Add(tbl_color3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_color3);
        }

        // GET: AdminPanel/tbl_color3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color3 tbl_color3 = db.tbl_color3.Find(id);
            if (tbl_color3 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color3);
        }

        // POST: AdminPanel/tbl_color3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description")] tbl_color3 tbl_color3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_color3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_color3);
        }

        // GET: AdminPanel/tbl_color3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color3 tbl_color3 = db.tbl_color3.Find(id);
            if (tbl_color3 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color3);
        }

        // POST: AdminPanel/tbl_color3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_color3 tbl_color3 = db.tbl_color3.Find(id);
            db.tbl_color3.Remove(tbl_color3);
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
