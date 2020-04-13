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
    public class tbl_parallaxController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_parallax
        public ActionResult Index()
        {
            return View(db.tbl_parallax.ToList());
        }

        // GET: AdminPanel/tbl_parallax/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax tbl_parallax = db.tbl_parallax.Find(id);
            if (tbl_parallax == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax);
        }

        // GET: AdminPanel/tbl_parallax/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_parallax/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description,Photo")] tbl_parallax tbl_parallax)
        {
            if (ModelState.IsValid)
            {
                db.tbl_parallax.Add(tbl_parallax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_parallax);
        }

        // GET: AdminPanel/tbl_parallax/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax tbl_parallax = db.tbl_parallax.Find(id);
            if (tbl_parallax == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax);
        }

        // POST: AdminPanel/tbl_parallax/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description,Photo")] tbl_parallax tbl_parallax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_parallax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_parallax);
        }

        // GET: AdminPanel/tbl_parallax/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax tbl_parallax = db.tbl_parallax.Find(id);
            if (tbl_parallax == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax);
        }

        // POST: AdminPanel/tbl_parallax/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_parallax tbl_parallax = db.tbl_parallax.Find(id);
            db.tbl_parallax.Remove(tbl_parallax);
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
