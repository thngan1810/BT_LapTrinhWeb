using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _26_BuiNgocThanhNgan_Tuan02.Models
{
    public class PhongBan
    {
        public PhongBan(string maphong, string tenphong)
        {
            Maphong = maphong;
            Tenphong = tenphong;
        }
        public PhongBan()
        {
            Maphong = "P1";
            Tenphong = "Phòng giám đốc";
        }
        public string Maphong { get; set; }
        public string Tenphong {  get; set; }

    }
}