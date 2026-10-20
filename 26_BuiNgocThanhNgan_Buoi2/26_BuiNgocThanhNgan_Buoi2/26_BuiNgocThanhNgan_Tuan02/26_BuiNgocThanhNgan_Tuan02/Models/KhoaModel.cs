using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _26_BuiNgocThanhNgan_Tuan02.Models
{
    public class KhoaModel
    {
        

        public string TenKhoa {  get; set; }
        public int NamThanhLap {  get; set; }
        public string ThongBao {  get; set; }

        public KhoaModel(string tenKhoa, int namThanhLap, string thongBao)
        {
            TenKhoa = tenKhoa;
            NamThanhLap = namThanhLap;
            ThongBao = thongBao;
        }
        public KhoaModel()
        {
            TenKhoa = "Khoa Công nghệ Thông tin ";
            NamThanhLap = 2003;
            ThongBao = "Chào mừng các bạn đến với HUIT";
        }
    }
}