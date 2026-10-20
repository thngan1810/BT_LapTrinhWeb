using _26_BuiNgocThanhNgan_Buoi09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            Sach sach=data.Saches.FirstOrDefault(s=>s.MaSach==msp);
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
        [HttpPost]
        public ActionResult Timkiem(FormCollection fc)
        {
            List<Sach> ds = data.Saches.ToList();

            if (fc["txtTuKhoa"] != "") 
            {
                string tk = fc["txtTuKhoa"];
                ds = ds.Where(t => t.TenSach.Contains(tk)).ToList();
            }
            int macd = int.Parse(fc["MaChuDe"].ToString());
            ds = ds.Where(t => t.MaChuDe == macd).ToList();

            int c1 = fc["ck1"] != null ? int.Parse(fc["ck1"].ToString()) : 0;
            int c2 = fc["ck2"] != null ? int.Parse(fc["ck2"].ToString()) : 0;
            int c3 = fc["ck3"] != null ? int.Parse(fc["ck3"].ToString()) : 0;
            int c4 = fc["ck4"] != null ? int.Parse(fc["ck4"].ToString()) : 0;

            if (c1 == 1) ds = ds.Where(s => s.GiaBan >= 0 && s.GiaBan <= 10000).ToList();
            if (c2 == 2) ds = ds.Where(s => s.GiaBan >= 11000 && s.GiaBan <= 20000).ToList();
            if (c3 == 3) ds = ds.Where(s => s.GiaBan >= 21000 && s.GiaBan <= 40000).ToList();
            if (c4 == 4) ds = ds.Where(s => s.GiaBan > 40000).ToList();

            ViewBag.MaChuDe = new SelectList(data.ChuDes.ToList(), "MaChuDe", "TenChuDe");

            return View(ds);

        }
    }
}