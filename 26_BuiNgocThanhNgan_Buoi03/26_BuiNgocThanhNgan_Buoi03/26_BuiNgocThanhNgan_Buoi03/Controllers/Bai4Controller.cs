using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _26_BuiNgocThanhNgan_Buoi03.Models;
namespace _26_BuiNgocThanhNgan_Buoi03.Controllers
{
    public class Bai4Controller : Controller
    {
        // GET: Bai4
        public ActionResult Bai4()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HienThi(ThongTin info)
        {

            return View(info);
        }
    }
}