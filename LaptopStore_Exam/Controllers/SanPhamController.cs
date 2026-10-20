using System.Web.Mvc;
using LaptopStore.Models;

namespace LaptopStore.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly DuLieu db = new DuLieu();

        public ActionResult Index(string q, int? maDanhMuc)
        {
            ViewBag.DanhMuc = db.LayDanhMuc();
            ViewBag.TinTuc = db.LayTinTuc();
            ViewBag.MaDanhMuc = maDanhMuc;
            ViewBag.TuKhoa = q ?? "";

            return View(db.LaySanPham(q, maDanhMuc));
        }

        public ActionResult Details(int id)
        {
            var sp = db.LaySanPham(id);
            if (sp == null) return HttpNotFound();

            sp.DungLuongs = db.LayDungLuong(id);
            ViewBag.DanhMuc = db.LayDanhMuc();
            ViewBag.TinTuc = db.LayTinTuc();
            return View(sp);
        }
    }
}
