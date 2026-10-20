using System.Web.Mvc;
using LaptopStore.Models;

namespace LaptopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DuLieu db = new DuLieu();

        public ActionResult Index(string q)
        {
            ViewBag.MaSo = "305050546";
            ViewBag.HoTen = "Nguyễn Văn A";
            ViewBag.SoThich = new[] { "Xem phim", "Nghe nhạc" };

            ViewBag.DanhMuc = db.LayDanhMuc();
            ViewBag.TinTuc = db.LayTinTuc();
            ViewBag.TuKhoa = q ?? "";

            return View(db.LaySanPham(q));
        }
    }
}
