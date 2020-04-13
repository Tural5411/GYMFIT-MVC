﻿using System;
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
    public class tbl_parallax2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_parallax2
        public ActionResult Index()
        {
            return View(db.tbl_parallax2.ToList());
        }

        // GET: AdminPanel/tbl_parallax2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax2 tbl_parallax2 = db.tbl_parallax2.Find(id);
            if (tbl_parallax2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax2);
        }

        // GET: AdminPanel/tbl_parallax2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_parallax2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description")] tbl_parallax2 tbl_parallax2)
        {
            if (ModelState.IsValid)
            {
                db.tbl_parallax2.Add(tbl_parallax2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_parallax2);
        }

        // GET: AdminPanel/tbl_parallax2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax2 tbl_parallax2 = db.tbl_parallax2.Find(id);
            if (tbl_parallax2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax2);
        }

        // POST: AdminPanel/tbl_parallax2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description")] tbl_parallax2 tbl_parallax2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_parallax2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_parallax2);
        }

        // GET: AdminPanel/tbl_parallax2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_parallax2 tbl_parallax2 = db.tbl_parallax2.Find(id);
            if (tbl_parallax2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_parallax2);
        }

        // POST: AdminPanel/tbl_parallax2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_parallax2 tbl_parallax2 = db.tbl_parallax2.Find(id);
            db.tbl_parallax2.Remove(tbl_parallax2);
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
