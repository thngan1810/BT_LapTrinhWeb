using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace _26_BuiNgocThanhNgan_Buoi06.Models
{
    public class DanhMuc
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
    }

    public class Tour
    {
        public int MaTour { get; set; }
        public string TenTour { get; set; }
        public DateTime? NgayKhoiHanh { get; set; }
        public string NoiKhoiHanh { get; set; }
        // CSDL đề bài không có cột thời gian lưu trú, nên thuộc tính này được giữ theo yêu cầu Model.
        public string ThoiGianLuuTru { get; set; }
        public int GiaTour { get; set; }
        public string ChuongTrinhTour { get; set; }
        public string DiaDiemThamQuan { get; set; }
        public int? MaDanhMuc { get; set; }
        public string Hinh { get; set; }
        public List<string> DsHinh { get; set; } = new List<string>();
    }

    public class DichVuKemTour
    {
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int MaTour { get; set; }
    }

    public class KhachHang
    {
        public int MaKhachHang { get; set; }
        public string TenKH { get; set; }
        public string SoDT { get; set; }
        public string MatKhau { get; set; }
    }

    public class Dulieu
    {
        // Nếu SQL Server trên máy m dùng tên instance khác, chỉ cần đổi Data Source.
        private static readonly string strcon =
            "Data Source=localhost\\SQLEXPRESS;database=TourDuLich_N2_CNW_09DHTH;Integrated Security=True";

        private readonly SqlConnection con = new SqlConnection(strcon);

        public List<DanhMuc> dsDanhMuc = new List<DanhMuc>();
        public List<Tour> dsTour = new List<Tour>();
        public List<DichVuKemTour> dsDichVu = new List<DichVuKemTour>();
        public List<KhachHang> dsKhachHang = new List<KhachHang>();

        public Dulieu()
        {
            ThietLap_DanhMuc();
            ThietLap_Tour();
            ThietLap_DichVu();
            ThietLap_KhachHang();
        }

        private string ChuanHoaHinh(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten)) return "";
            ten = Path.GetFileName(ten.Trim());
            string khongDuoi = Path.GetFileNameWithoutExtension(ten);
            // Bộ ảnh trong project mẫu là .png, trong SQL có dữ liệu .jpg.
            return khongDuoi + ".png";
        }

        private List<string> TachDanhSachHinh(string dsHinh)
        {
            if (string.IsNullOrWhiteSpace(dsHinh)) return new List<string>();
            return dsHinh.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(ChuanHoaHinh)
                         .Where(x => !string.IsNullOrWhiteSpace(x))
                         .ToList();
        }

        public void ThietLap_DanhMuc()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Danhmuc", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dsDanhMuc.Add(new DanhMuc
                {
                    MaDanhMuc = Convert.ToInt32(dr["MaDM"]),
                    TenDanhMuc = dr["TenDM"].ToString()
                });
            }
        }

        public void ThietLap_Tour()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tour", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var t = new Tour
                {
                    MaTour = Convert.ToInt32(dr["MaTour"]),
                    TenTour = dr["TenTour"].ToString(),
                    NoiKhoiHanh = dr["NoiKhoiHanh"].ToString(),
                    ChuongTrinhTour = dr["ChuongTrinhTour"].ToString(),
                    DiaDiemThamQuan = dr["NoiThamQuan"].ToString(),
                    Hinh = ChuanHoaHinh(dr["hinh"].ToString()),
                    DsHinh = TachDanhSachHinh(dr["dsHinh"].ToString())
                };

                if (dr["NgayDi"] != DBNull.Value)
                    t.NgayKhoiHanh = Convert.ToDateTime(dr["NgayDi"]);
                if (dr["GiaVe"] != DBNull.Value)
                    t.GiaTour = Convert.ToInt32(dr["GiaVe"]);
                if (dr["MaDM"] != DBNull.Value)
                    t.MaDanhMuc = Convert.ToInt32(dr["MaDM"]);

                dsTour.Add(t);
            }
        }

        public void ThietLap_DichVu()
        {
            string sql = @"
                SELECT ct.MaDV, dv.TenDichVu, ct.MaTour
                FROM ChiTietTour ct
                INNER JOIN DichVu dv ON ct.MaDV = dv.MaDD";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dsDichVu.Add(new DichVuKemTour
                {
                    MaDichVu = Convert.ToInt32(dr["MaDV"]),
                    TenDichVu = dr["TenDichVu"].ToString(),
                    MaTour = Convert.ToInt32(dr["MaTour"])
                });
            }
        }

        public void ThietLap_KhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dsKhachHang.Add(new KhachHang
                {
                    MaKhachHang = Convert.ToInt32(dr["MaKH"]),
                    TenKH = dr["TenKH"].ToString(),
                    SoDT = dr["SoDT"].ToString(),
                    MatKhau = dr["MatKhau"].ToString()
                });
            }
        }
    }
}
