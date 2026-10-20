using _26_BuiNgocThanhNgan_Buoi06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi06.Controllers
{
    public class Bai1Controller : Controller
    {
        // GET: Bai1
        DuLieuSP dataSP=new DuLieuSP();
        public ActionResult Index()
        {
            return View(dataSP.dsSP);
        }
        public ActionResult Menu()
        {
            return PartialView(dataSP.dsLoai);
        }
        public ActionResult HTSP(int ml)
        {
            List<SanPham>dssp=dataSP.dsSP.Where(s=>s.MaL==ml).ToList();
            return View("Index",dssp);
        }
        public ActionResult XemChiTiet(string msp)
        {
            SanPham sp = dataSP.dsSP.FirstOrDefault(s => s.MaSP == msp);
            return View(sp);
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLDangNhap(string txtSDT,string txtMK)
        {
            KhachHang k=dataSP.dskh.FirstOrDefault(item=>item.SDT==txtSDT&&item.MK==txtMK);
            if(k!=null)
            {
                ViewBag.tb = "Bạn chưa lưu thông tin. Đăng nhập thất bại";
                return View("DangNhap");
            }
            else
            {
                Session["k"] = k;
            }
            return RedirectToAction("Index");
        }
    }
}