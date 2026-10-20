using _26_BuiNgocThanhNgan_Buoi06.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi06.Controllers
{
    public class Bai1Controller : Controller
    {
        private readonly Dulieu data = new Dulieu();

        // Bài 1: Trang chủ + ViewBag
        public ActionResult Index(string tenTour = "")
        {
            ViewBag.MaSoSV = "26"; // Thay bằng MSSV thật nếu số 26 trong tên project là STT.
            ViewBag.HoTenSV = "Bùi Ngọc Thanh Ngân";
            ViewBag.SoThich = new List<string> { "Du lịch", "Nghe nhạc", "Xem phim" };

            IEnumerable<Tour> ds = data.dsTour;
            if (!string.IsNullOrWhiteSpace(tenTour))
                ds = ds.Where(t => t.TenTour.ToLower().Contains(tenTour.Trim().ToLower()));

            ViewBag.TuKhoa = tenTour;
            return View(ds.ToList());
        }

        // Menu danh mục ở cột trái
        public ActionResult Menu()
        {
            return PartialView(data.dsDanhMuc);
        }

        // Lọc tour theo danh mục
        public ActionResult HTTour(int maDM, string tenTour = "")
        {
            IEnumerable<Tour> ds = data.dsTour.Where(t => t.MaDanhMuc == maDM);

            if (!string.IsNullOrWhiteSpace(tenTour))
                ds = ds.Where(t => t.TenTour.ToLower().Contains(tenTour.Trim().ToLower()));

            ViewBag.MaDM = maDM;
            ViewBag.TuKhoa = tenTour;
            ViewBag.TenDanhMuc = data.dsDanhMuc.FirstOrDefault(x => x.MaDanhMuc == maDM)?.TenDanhMuc;
            return View("Index", ds.ToList());
        }

        // Bài 3: Chi tiết tour
        public ActionResult XemChiTiet(int maTour)
        {
            Tour tour = data.dsTour.FirstOrDefault(t => t.MaTour == maTour);
            if (tour == null) return HttpNotFound();

            ViewBag.DichVu = data.dsDichVu.Where(d => d.MaTour == maTour).ToList();
            return View(tour);
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XLDangNhap(string txtSDT, string txtMK)
        {
            KhachHang kh = data.dsKhachHang.FirstOrDefault(
                item => item.SoDT == txtSDT && item.MatKhau == txtMK);

            if (kh == null)
            {
                ViewBag.tb = "Số điện thoại hoặc mật khẩu không đúng.";
                return View("DangNhap");
            }

            Session["k"] = kh;
            return RedirectToAction("Index");
        }
    }
}
