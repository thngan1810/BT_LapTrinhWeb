using System;
using System.Collections.Generic;

namespace LaptopStore.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public int MaDanhMuc { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public string TinhTrang { get; set; }
        public decimal? Gia { get; set; }
        public string HinhAnh { get; set; }
        public string CauHinh { get; set; }
        public string UuDiem { get; set; }
        public List<DungLuong> DungLuongs { get; set; }
    }
}
