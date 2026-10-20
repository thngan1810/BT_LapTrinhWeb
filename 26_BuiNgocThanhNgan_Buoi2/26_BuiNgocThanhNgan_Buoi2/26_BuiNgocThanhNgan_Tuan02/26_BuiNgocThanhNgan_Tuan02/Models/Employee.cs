using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _26_BuiNgocThanhNgan_Tuan02.Models
{
    public class Employee
    {
        public string manv { get; set; }
        public string tennv { get; set; }
        public string gioitinh { get; set; }
        public string anhthe {  get; set; }
        public double luong { get; set; }
        public Employee() 
        {
            manv = "NV001";
            tennv = "Nguyễn Văn A";
            gioitinh = "Nam";
            anhthe = "hinh1.jpg";
            luong = 5000000;
        }
        public Employee(string ma,string ten,string gt,string hinh,double luong)
        {
            manv = ma;  
            tennv = ten;
            gioitinh = gt;
            anhthe = hinh;
            this.luong = luong;
        }


    }
}