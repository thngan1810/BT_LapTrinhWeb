using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _26_BuiNgocThanhNgan_Buoi03.Models;

namespace _26_BuiNgocThanhNgan_Buoi03.Controllers
{
    public class Bai3Controller : Controller
    {
        // GET: Bai3
        public ActionResult Bai3()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(SanPham sp)
        {
            ViewBag.SanPham = sp;
            return View();
        }
    }
}