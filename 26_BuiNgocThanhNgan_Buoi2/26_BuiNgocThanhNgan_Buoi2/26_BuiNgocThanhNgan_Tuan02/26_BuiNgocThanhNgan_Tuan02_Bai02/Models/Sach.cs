using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace _26_BuiNgocThanhNgan_Tuan02_Bai02.Models
{
    public class Sach
    {
        public string Masach {  get; set; }
        public string Tensach {  get; set; }
        public double Gia {  get; set; }
        public string AnhBia {  get; set; }
        public string Tacgia {  get; set; }
        public string Motasp { get; set; }
        public Sach() 
        {
            Masach = "SH01";
            Tensach = "Lẽ Nào Em Không Biết";
            Gia = 64200;
            AnhBia = "sach1.jpg";
            Tacgia = "Lan Rùa";
            Motasp = "Xoay quanh những đổ vỡ tình cảm, những thách thức, những sự lừa dối mà cô gái trẻ Như Nguyệt phải chịu đựng, chuyện tình yêu của Em là nhà sẽ đưa bạn qua những cung bậc cảm xúc từ ngọt ngào đến cao trào uất hận, từ bình yên êm ấm đến những nỗi đau chỉ có thể âm thầm chịu đựng.";
        }

        public Sach(string masach, string tensach, double gia, string anhBia, string tacgia, string motasp)
        {
            Masach = masach;
            Tensach = tensach;
            Gia = gia;
            AnhBia = anhBia;
            Tacgia = tacgia;
            Motasp = motasp;
        }
    }
    public class Data
    {
        public List<Sach> saches { get; set; }
        public Data() {
            saches = new List<Sach>();
            saches.Add(new Sach());
            saches.Add(new Sach("SH02", "Em là nhà", 58800, "sach2.jpg", "Lan Rùa", "Xoay quanh những đổ vỡ tình cảm, những thách thức, những sự lừa dối mà cô gái trẻ Như Nguyệt phải chịu đựng, chuyện tình yêu của Em là nhà sẽ đưa bạn qua những cung bậc cảm xúc từ ngọt ngào đến cao trào uất hận, từ bình yên êm ấm đến những nỗi đau chỉ có thể âm thầm chịu đựng."));
            saches.Add(new Sach("Sh03", "Khu vườn ngôn từ", 71250, "sach3.jpg", "Nguyen van a", "sách hay ...."));
            saches.Add(new Sach("SH04", "Người truyền ký ức", 49640, "sach4.jpg", "tran van b", "cũng cũng.."));
            saches.Add(new Sach("SH05", "Đạo tình", 77000, "sach5.jpg", "xyz", "hắc bang đồ đồ á...."));
            saches.Add(new Sach("SH06", "Yêu", 52200, "sach6.jpg", "fygafgoaefoehgfow", "tầgefgaifgaei"));
            saches.Add(new Sach("SH07", "Kỳ án ánh trăng", 115500, "sach7.jpg", "ânfoafho0", "kịch tính, sss sff uih"));
            saches.Add(new Sach("SH08", "Cuộc sống không giới hạn", 74000, "sach8.jpg", "Lê Thị M", "cuộc sống không giới hạn"));
        }
    }
}