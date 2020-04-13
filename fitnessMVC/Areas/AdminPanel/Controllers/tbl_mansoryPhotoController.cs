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
    public class tbl_mansoryPhotoController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_mansoryPhoto
        public ActionResult Index()
        {
            return View(db.tbl_mansoryPhoto.ToList());
        }

        // GET: AdminPanel/tbl_mansoryPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mansoryPhoto tbl_mansoryPhoto = db.tbl_mansoryPhoto.Find(id);
            if (tbl_mansoryPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mansoryPhoto);
        }

        // GET: AdminPanel/tbl_mansoryPhoto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_mansoryPhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,longphoto,normalPhoto,Header")] tbl_mansoryPhoto tbl_mansoryPhoto, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Photo.ContentLength > 0)
                    {
                        if (Photo.ContentType.ToLower() == "image/jpg" ||
                            Photo.ContentType.ToLower() == "image/jpeg" ||
                            Photo.ContentType.ToLower() == "image/png")
                        {
                            WebImage image = new WebImage(Photo.InputStream);
                            FileInfo info = new FileInfo(Photo.FileName);
                            string filename = Guid.NewGuid().ToString() + info;
                            image.Save("~/Upload/Mansory/" + filename);
                            tbl_mansoryPhoto.normalPhoto = "/Upload/Mansory/" + filename;
                            db.tbl_mansoryPhoto.Add(tbl_mansoryPhoto);
                            db.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            return View(tbl_mansoryPhoto);
        }

        // GET: AdminPanel/tbl_mansoryPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mansoryPhoto tbl_mansoryPhoto = db.tbl_mansoryPhoto.Find(id);
            if (tbl_mansoryPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mansoryPhoto);
        }

        // POST: AdminPanel/tbl_mansoryPhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,longphoto,normalPhoto,Header")] tbl_mansoryPhoto tbl_mansoryPhoto, HttpPostedFileBase normalPhoto, int? id)
        {
            if (ModelState.IsValid)
            {
                tbl_mansoryPhoto selectedPhoto = db.tbl_mansoryPhoto.FirstOrDefault(x => x.Id == id);
                if (normalPhoto != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(selectedPhoto.normalPhoto)))
                    {
                        System.IO.File.Delete(Server.MapPath(selectedPhoto.normalPhoto));
                    }
                    WebImage img = new WebImage(normalPhoto.InputStream);
                    FileInfo info = new FileInfo(normalPhoto.FileName);
                    string filename = Guid.NewGuid().ToString() + info.Extension;
                    img.Save("~/Upload/Mansory/" + filename);
                    tbl_mansoryPhoto.normalPhoto = "/Upload/Mansory/" + filename;
                }

                selectedPhoto.normalPhoto = tbl_mansoryPhoto.normalPhoto;
                selectedPhoto.Header = tbl_mansoryPhoto.Header;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_mansoryPhoto);
        }

        // GET: AdminPanel/tbl_mansoryPhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mansoryPhoto tbl_mansoryPhoto = db.tbl_mansoryPhoto.Find(id);
            if (tbl_mansoryPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mansoryPhoto);
        }

        // POST: AdminPanel/tbl_mansoryPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_mansoryPhoto tbl_mansoryPhoto = db.tbl_mansoryPhoto.Find(id);
            db.tbl_mansoryPhoto.Remove(tbl_mansoryPhoto);
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
