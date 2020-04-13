using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using fitnessMVC.Model;

namespace fitnessMVC.Areas.AdminPanel.Controllers
{
    public class tbl_mainPostController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_mainPost
        public ActionResult Index()
        {
            var tbl_mainPost = db.tbl_mainPost.Include(t => t.tbl_post_category).Include(t => t.tbl_user);
            return View(tbl_mainPost.ToList());
        }

        // GET: AdminPanel/tbl_mainPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mainPost tbl_mainPost = db.tbl_mainPost.Find(id);
            if (tbl_mainPost == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mainPost);
        }

        // GET: AdminPanel/tbl_mainPost/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.tbl_post_category, "Id", "CategoryName");
            ViewBag.UserId = new SelectList(db.tbl_user, "Id", "UserName");
            return View();
        }

        // POST: AdminPanel/tbl_mainPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,CategoryId,UserId,Header,Context,Photo,PostTime")] tbl_mainPost tbl_mainPost, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Photo.ContentLength > 0)
                    {
                        if (Photo.ContentType.ToLower() == "image/jpg" ||
                            Photo.ContentType.ToLower() == "image/jpeg" ||
                            Photo.ContentType.ToLower() == "image/gif" ||
                            Photo.ContentType.ToLower() == "image/png")
                        {
                            WebImage image = new WebImage(Photo.InputStream);
                            FileInfo info = new FileInfo(Photo.FileName);
                            string filename = Guid.NewGuid().ToString() + info.Extension;
                            image.Save("~/Upload/MainPost/" + filename);
                            tbl_mainPost.Photo = "/Upload/MainPost/" + filename;
                            db.tbl_mainPost.Add(tbl_mainPost);
                            db.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.tbl_post_category, "Id", "CategoryName", tbl_mainPost.CategoryId);
            ViewBag.UserId = new SelectList(db.tbl_user, "Id", "UserName", tbl_mainPost.UserId);
            return View(tbl_mainPost);
        }
        // GET: AdminPanel/tbl_mainPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mainPost tbl_mainPost = db.tbl_mainPost.Find(id);
            if (tbl_mainPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.tbl_post_category, "Id", "CategoryName", tbl_mainPost.CategoryId);
            ViewBag.UserId = new SelectList(db.tbl_user, "Id", "UserName", tbl_mainPost.UserId);
            return View(tbl_mainPost);
        }

        // POST: AdminPanel/tbl_mainPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,UserId,Header,Context,Photo,PostTime")] tbl_mainPost tbl_mainPost, HttpPostedFileBase Photo, int? id)
        {
            if (ModelState.IsValid)
            {
                tbl_mainPost selectedPost = db.tbl_mainPost.FirstOrDefault(x => x.Id == id);
                if (Photo != null)
                {
                    if (Photo.ContentLength > 0)
                    {
                        if (Photo.ContentType.ToLower() == "image/jpg" ||
                            Photo.ContentType.ToLower() == "image/jpeg" ||
                            Photo.ContentType.ToLower() == "image/gif" ||
                            Photo.ContentType.ToLower() == "image/png")
                        {
                            WebImage image = new WebImage(Photo.InputStream);
                            FileInfo info = new FileInfo(Photo.FileName);
                            string filename = "mainPhoto" + Guid.NewGuid().ToString() + info.Extension;
                            image.Save("~/Upload/mainPost/" + filename);
                            tbl_mainPost.Photo = "/Upload/mainPost/" + filename;
                           
                        }
                    }
                }
                selectedPost.Photo = tbl_mainPost.Photo;
                selectedPost.Header = tbl_mainPost.Header;
                selectedPost.Context = tbl_mainPost.Context;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.tbl_post_category, "Id", "CategoryName", tbl_mainPost.CategoryId);
            ViewBag.UserId = new SelectList(db.tbl_user, "Id", "UserName", tbl_mainPost.UserId);
            return View(tbl_mainPost);
        }

        // GET: AdminPanel/tbl_mainPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mainPost tbl_mainPost = db.tbl_mainPost.Find(id);
            if (tbl_mainPost == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mainPost);
        }

        // POST: AdminPanel/tbl_mainPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_mainPost tbl_mainPost = db.tbl_mainPost.Find(id);
            db.tbl_mainPost.Remove(tbl_mainPost);
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
