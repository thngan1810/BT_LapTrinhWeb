using _26_BuiNgocThanhNgan_Buoi09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi09.Controllers
{
    public class Bai1Controller : Controller
    {
        // GET: Bai
        QuanLyBanSachEntities data=new QuanLyBanSachEntities();

        public ActionResult Index()
        {
            List<Sach>dsSach=data.Saches.OrderByDescending(s=>s.NgayCapNhat).ToList();
            return View(dsSach);
        }
        public ActionResult DSMenu_ChuDe()
        {
            List<ChuDe>dscd=data.ChuDes.Take(10).ToList();
            return PartialView(dscd);
        }
        public ActionResult HTSachTheoChuDe(int mcd)
        {
            List<Sach> dsSach = data.Saches
                .Where(s => s.MaChuDe == mcd)
                .ToList();

            return View("Index", dsSach);
        }
        public ActionResult DSMenu_NXB()
        {
            List<NhaXuatBan> dsNXB = data.NhaXuatBans.Take(10).ToList();
            return PartialView(dsNXB);
        }
        public ActionResult HTSachTheoNXB(int mnxb)
        {
            List<Sach> dsSach = data.Saches
                .Where(s => s.MaNXB == mnxb)
                .ToList();

            return View("Index", dsSach);
        }
        public ActionResult XemChiTiet(int msp)
        {
            Sach sach=data.Saches.FirstOrDefault(s=>s.MaNXB==msp);
            List<ThamGia>dsThamgia=data.ThamGias.Where(t=>t.MaSach==msp).ToList();
            ViewBag.dsthamgia=dsThamgia;
            List<Sach>ds1=data.Saches.Where(s => s.MaChuDe==sach.MaChuDe).ToList();
            ViewBag.ds1 = ds1;
            List<Sach> ds2 = data.Saches.Where(s => s.MaNXB == sach.MaNXB).ToList();
            ViewBag.ds2 = ds2;
            return View(sach);
        }
        public ActionResult Timkiem()
        {
           
            ViewBag.MaChuDe=new SelectList(data.ChuDes.ToList(),"MaChuDe","TenChuDe");
            return View();
        }
    }
}