using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _26_BuiNgocThanhNgan_Buoi06.Models
{
    public class SanPham
    {
        public string MaSP {  get; set; }
        public string TenSP {  get; set; }
        public int MaL {  get; set; }
        public int MaSX {  get; set; }
        public float Gia { get; set; }
        public string GhiChu {  get; set; }
        public string Hinh {  get; set; }
    }
    public class Loai
    {
        public int MaLoai { get; set; }
        public string TenLoai {  get; set; }
    }
    public class KhachHang
    {
        public int MaKhachHang {  get; set; }
        public string TenKH {  get; set; }
        public string SDT { get; set; }
        public string MK {  get; set; }
    }
    public class DuLieuSP
    {
        static string strcon = "Data Source=localhost\\SQLEXPRESS;database=QLSanPham;Integrated Security=True";
        SqlConnection con = new SqlConnection(strcon);
        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();
        public List<KhachHang> dskh = new List<KhachHang>();
        public DuLieuSP()
        {
            ThietLap_DSLoai();
            ThietLap_DSSP();
            ThietLap_DSKH();
        }
        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp=new SanPham();
                sp.MaSP = dr["MaSanPham"].ToString();
                sp.TenSP = dr["TenSP"].ToString() ;
                sp.MaL = (int)dr["MaL"];
                sp.MaSX = (int)dr["MaSX"];
                sp.Gia = float.Parse(dr["Gia"].ToString());
                sp.GhiChu = dr["GhiChu"].ToString();
                sp.Hinh = dr["Hinh"].ToString();
                dsSP.Add(sp);
            }
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var l = new Loai();
                l.MaLoai = (int)dr["MaLoai"];
                l.TenLoai = dr["TenLoai"].ToString();
                dsLoai.Add(l);
            }
        }
        public void ThietLap_DSKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_KhachHang", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var k = new KhachHang();
                k.MaKhachHang = (int)dr["MaKhachHang"];
                k.TenKH = dr["TenKhachHang"].ToString() ;
                k.SDT = dr["SoDienThoai"].ToString();
                k.MK = dr["MatKhau"].ToString();
                dskh.Add(k);
            }
        }
    }
}