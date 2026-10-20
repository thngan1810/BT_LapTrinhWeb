using _26_BuiNgocThanhNgan_Tuan02_Bai02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Tuan02_Bai02.Controllers
{
    public class HomeController : Controller
    {
        Data csdl = new Data();
        public ActionResult SACH()
        {

            List<Sach> dss = csdl.saches;
            return View(dss);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ChonMua(string ms)
        {
            Sach s = csdl.saches.FirstOrDefault(i => i.Masach == ms);
            return View(s);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}