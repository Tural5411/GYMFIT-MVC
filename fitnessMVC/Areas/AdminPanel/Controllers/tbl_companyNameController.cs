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
    public class tbl_companyNameController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_companyName
        public ActionResult Index()
        {
            return View(db.tbl_companyName.ToList());
        }

        // GET: AdminPanel/tbl_companyName/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_companyName tbl_companyName = db.tbl_companyName.Find(id);
            if (tbl_companyName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_companyName);
        }

        // GET: AdminPanel/tbl_companyName/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_companyName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description")] tbl_companyName tbl_companyName)
        {
            if (ModelState.IsValid)
            {
                db.tbl_companyName.Add(tbl_companyName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_companyName);
        }

        // GET: AdminPanel/tbl_companyName/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_companyName tbl_companyName = db.tbl_companyName.Find(id);
            if (tbl_companyName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_companyName);
        }

        // POST: AdminPanel/tbl_companyName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description")] tbl_companyName tbl_companyName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_companyName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_companyName);
        }

        // GET: AdminPanel/tbl_companyName/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_companyName tbl_companyName = db.tbl_companyName.Find(id);
            if (tbl_companyName == null)
            {
                return HttpNotFound();
            }
            return View(tbl_companyName);
        }

        // POST: AdminPanel/tbl_companyName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_companyName tbl_companyName = db.tbl_companyName.Find(id);
            db.tbl_companyName.Remove(tbl_companyName);
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
