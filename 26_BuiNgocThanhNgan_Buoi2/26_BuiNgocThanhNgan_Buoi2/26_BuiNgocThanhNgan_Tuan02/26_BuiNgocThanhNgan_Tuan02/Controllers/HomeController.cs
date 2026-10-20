using _26_BuiNgocThanhNgan_Tuan02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Tuan02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Cau1()
        {
            List<string> danhsach = new List<string>();
            danhsach.Add("Trương Mạnh Hùng");
            danhsach.Add("Nguyễn Hải Yến");
            danhsach.Add("Trương Thị Khánh Uyên");
            danhsach.Add("Trương Nguyễn Quỳnh Anh");
            danhsach.Add("abczyx");
            ViewBag.dulieu=danhsach;
            return View();
        }
        public ActionResult Cau2()
        {
            List<string> danhsach = new List<string>();
            danhsach.Add("Cam");
            danhsach.Add("Xoài");
            danhsach.Add("Cóc ");
            danhsach.Add("Ổi");
            danhsach.Add("Mận");
            ViewBag.dulieu = danhsach;
            return View();
        }
        public ActionResult Cau3()
        {
            Employee e = new Employee();
            ViewData["em"] = e;

            return View();
        }
        public ActionResult Cau4()
        {
            KhoaModel a = new KhoaModel();
            a.ThongBao = "FIT - HUFI: HỌC TẬP - NĂNG ĐỘNG - SÁNG TẠO";
            return View(a);
        }
        public ActionResult Cau5()
        {
            List<PhongBan> a = new List<PhongBan>();
            a.Add(new PhongBan());
            a.Add(new PhongBan("P2","Phòng tài chính"));
            a.Add(new PhongBan("P3", "Phòng kế hoạch"));
            a.Add(new PhongBan("P4", "Phòng kế toán"));
            a.Add(new PhongBan("P5", "Phòng sản xuất"));
            a.Add(new PhongBan("P6", "Phòng kinh doanh"));
            return View(a);
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
    }
}