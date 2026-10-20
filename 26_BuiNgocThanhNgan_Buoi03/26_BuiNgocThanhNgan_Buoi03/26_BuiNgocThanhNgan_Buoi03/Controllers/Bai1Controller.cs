using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi03.Controllers
{
    public class Bai1Controller : Controller
    {
        // GET: Bai1
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLTuKhoa(string txtTukhoa)
        {
            ViewBag.tk = "Tên sách cần tìm có từ khóa là: " + txtTukhoa;
            return View();
        }
    }
}