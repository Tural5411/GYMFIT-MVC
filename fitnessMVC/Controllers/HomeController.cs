using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using fitnessMVC.Model;
using PagedList;
using PagedList.Mvc;
namespace fitnessMVC.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        [Route("")]
        [Route("Anasehife")]
        public ActionResult Index()
        {

            ViewBag.postlar = db.tbl_mainPost.ToList().OrderByDescending(x => x.Id);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult sliderPartial()
        {
            return View(db.tbl_slider.ToList());
        }
        public ActionResult colorPartial()
        {
            return View(db.tbl_color3.ToList());
        }
        public ActionResult parallax2Partial()
        {
            return View(db.tbl_parallax2.First());
        }
        public ActionResult mansoryPartial()
        {
            return View(db.tbl_mansoryPhoto.ToList());
        }

        
        public ActionResult Postpartial(int Page = 1)
        {
            return View(db.tbl_mainPost.OrderByDescending(x => x.Id).ToPagedList(Page, 6));
        }
        [Route("Postpartial/{CategoryName}/{id:int}")]
        public ActionResult categoryPost(int id, int Page = 1)
        {
            return View(db.tbl_mainPost.Include("tbl_post_category").Where(x => x.tbl_post_category.Id == id).OrderByDescending(x => x.Id).ToPagedList(Page, 5));
        }

        [Route("Postpartial/{header}-{id:int}")]
        public ActionResult postDetail(int? id)
        {
            //if (id == null) return HttpNotFound();
            //tbl_mainPost psDetail = db.tbl_mainPost.FirstOrDefault(x => x.Id == id);
            //if (psDetail == null) return HttpNotFound();
            var p = db.tbl_mainPost.Include("tbl_post_category").Where(x => x.Id == id).SingleOrDefault();
            return View(p);
        }

        public ActionResult morePost()
        {
            return View(db.tbl_mainPost.Take(3).ToList());
        }
        public ActionResult popularPost()
        {
            return View(db.tbl_mainPost.Take(4).ToList());
        }
        public ActionResult BlogCategoryPartial()
        {
            return PartialView(db.tbl_post_category.ToList().OrderBy(x => x.CategoryName));
        }
    }
}
