using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi03.Controllers
{
    public class Bai2Controller : Controller
    {
        // GET: Bai2
        public ActionResult Bai2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string username = c["username"];
            string password = c["password"];
            ViewBag.Message=$"Đăng nhập với user: {username} với password là: {password}";
            return View();
        }
    }
}