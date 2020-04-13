using fitnessMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fitnessMVC.Areas.AdminPanel.Controllers
{
    public class AdminHomeController : Controller
    {
        Model1 db = new Model1();
        // GET: AdminPanel/AdminHome
        //[Route("adminlogin")]
        public ActionResult Index()
        {
            var kateg = db.tbl_mainPost.ToList();
            return View(kateg);
        }
        //[Route("adminlogin/giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_admin admin)
        {
            var Login = db.tbl_admin.Where(x => x.email == admin.email).SingleOrDefault();
            if (Login.email == admin.email && Login.password == admin.password)
            {
                Session["email"] = Login.email;
                Session["adminId"] = Login.Id;
                return RedirectToAction("index", "AdminHome");
            }
            ViewBag.alert = "YALNIS!";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["adminId"] = null;
            Session["email"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "AdminHome");
        }


    }
}