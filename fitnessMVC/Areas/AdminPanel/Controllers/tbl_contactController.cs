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
    public class tbl_contactController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_contact
        public ActionResult Index()
        {
            return View(db.tbl_contact.ToList());
        }

        // GET: AdminPanel/tbl_contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_contact tbl_contact = db.tbl_contact.Find(id);
            if (tbl_contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_contact);
        }

        // GET: AdminPanel/tbl_contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Place,email,telephone")] tbl_contact tbl_contact)
        {
            if (ModelState.IsValid)
            {
                db.tbl_contact.Add(tbl_contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_contact);
        }

        // GET: AdminPanel/tbl_contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_contact tbl_contact = db.tbl_contact.Find(id);
            if (tbl_contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_contact);
        }

        // POST: AdminPanel/tbl_contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Place,email,telephone")] tbl_contact tbl_contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_contact);
        }

        // GET: AdminPanel/tbl_contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_contact tbl_contact = db.tbl_contact.Find(id);
            if (tbl_contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_contact);
        }

        // POST: AdminPanel/tbl_contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_contact tbl_contact = db.tbl_contact.Find(id);
            db.tbl_contact.Remove(tbl_contact);
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
