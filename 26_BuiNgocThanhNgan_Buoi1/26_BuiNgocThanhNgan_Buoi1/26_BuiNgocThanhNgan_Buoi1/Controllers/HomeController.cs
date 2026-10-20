using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult SV(int id)
        {
            ViewBag.ms = id;
            return View();
        }
        public ActionResult Index3(int ma,string ten)
        {
            ViewBag.id = ma;
            ViewBag.name = ten;
            return View();
        }
    }
}
