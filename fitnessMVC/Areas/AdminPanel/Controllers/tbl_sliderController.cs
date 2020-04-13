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
    public class tbl_sliderController : Controller
    {
        private Model1 db = new Model1();

        // GET: AdminPanel/tbl_slider
        public ActionResult Index()
        {
            return View(db.tbl_slider.ToList());
        }

        // GET: AdminPanel/tbl_slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slider tbl_slider = db.tbl_slider.Find(id);
            if (tbl_slider == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slider);
        }

        // GET: AdminPanel/tbl_slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/tbl_slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description,Photo")] tbl_slider tbl_slider,HttpPostedFileBase imgURL)
        {
            if (ModelState.IsValid)
            {
                if (imgURL != null)
                {
                    if(imgURL.ContentLength > 0)
                    {
                        if(imgURL.ContentType.ToLower() == "image/jpg" ||
                            imgURL.ContentType.ToLower() == "image/jpeg" ||
                            imgURL.ContentType.ToLower() == "image/png" ||
                            imgURL.ContentType.ToLower() =="image/gif"
                            )
                        {
                            WebImage img = new WebImage(imgURL.InputStream);
                            FileInfo info = new FileInfo(imgURL.FileName);
                            string filename = Guid.NewGuid().ToString() + info.Extension;
                            img.Save("~/Upload/Slider/" + filename);
                            tbl_slider.Photo = "/Upload/Slider/" + filename;
                            db.tbl_slider.Add(tbl_slider);
                            db.SaveChanges();

                        }
                    }
                }
               
                return RedirectToAction("Index");
            }

            return View(tbl_slider);
        }

        // GET: AdminPanel/tbl_slider/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slider tbl_slider = db.tbl_slider.Find(id);
            if (tbl_slider == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slider);
        }

        // POST: AdminPanel/tbl_slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description,Photo")]  tbl_slider tbl_slider,HttpPostedFileBase Photo,int? id)
        {
            if (ModelState.IsValid)
            {
                tbl_slider selectedslider = db.tbl_slider.FirstOrDefault(x => x.Id == id);
                if (Photo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(selectedslider.Photo)))
                    {
                        System.IO.File.Delete(Server.MapPath(selectedslider.Photo));
                    }
                    WebImage img = new WebImage(Photo.InputStream);
                    FileInfo info = new FileInfo(Photo.FileName);
                    string filename = Guid.NewGuid().ToString() + info.Extension;
                    img.Save("~/Upload/Slider/" + filename);
                    tbl_slider.Photo = "/Upload/Slider/" + filename;
                    
                }


                selectedslider.Header = tbl_slider.Header;
                selectedslider.Description = tbl_slider.Description;
                selectedslider.Photo = tbl_slider.Photo;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_slider);
        }

        // GET: AdminPanel/tbl_slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slider tbl_slider = db.tbl_slider.Find(id);
            if (tbl_slider == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slider);
        }

        // POST: AdminPanel/tbl_slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_slider tbl_slider = db.tbl_slider.Find(id);
            db.tbl_slider.Remove(tbl_slider);
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
