using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LaptopStore.Models
{
    public class DuLieu
    {
        private readonly string cn = ConfigurationManager.ConnectionStrings["LaptopStore"].ConnectionString;

        public List<DanhMuc> LayDanhMuc()
        {
            var ds = new List<DanhMuc>();
            using (var con = new SqlConnection(cn))
            using (var cmd = new SqlCommand("SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY MaDanhMuc", con))
            {
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ds.Add(new DanhMuc {
                            MaDanhMuc = rd.GetInt32(0),
                            TenDanhMuc = rd.IsDBNull(1) ? "" : rd.GetString(1)
                        });
                    }
                }
            }
            return ds;
        }

        public List<SanPham> LaySanPham(string tuKhoa = null, int? maDanhMuc = null)
        {
            var ds = new List<SanPham>();
            string sql = @"SELECT MaSanPham, MaDanhMuc, TenSanPham, MoTa, TinhTrang, Gia, HinhAnh, CauHinh, UuDiem
                           FROM SanPham
                           WHERE (@q = '' OR TenSanPham LIKE N'%' + @q + N'%')
                             AND (@madm IS NULL OR MaDanhMuc = @madm)
                           ORDER BY MaSanPham";

            using (var con = new SqlConnection(cn))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@q", tuKhoa ?? "");
                cmd.Parameters.AddWithValue("@madm", (object)maDanhMuc ?? DBNull.Value);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ds.Add(new SanPham {
                            MaSanPham = rd.GetInt32(0),
                            MaDanhMuc = rd.GetInt32(1),
                            TenSanPham = rd.IsDBNull(2) ? "" : rd.GetString(2),
                            MoTa = rd.IsDBNull(3) ? "" : rd.GetString(3),
                            TinhTrang = rd.IsDBNull(4) ? "" : rd.GetString(4),
                            Gia = rd.IsDBNull(5) ? (decimal?)null : rd.GetDecimal(5),
                            HinhAnh = rd.IsDBNull(6) ? "" : rd.GetString(6),
                            CauHinh = rd.IsDBNull(7) ? "" : rd.GetString(7),
                            UuDiem = rd.IsDBNull(8) ? "" : rd.GetString(8)
                        });
                    }
                }
            }
            return ds;
        }

        public SanPham LaySanPham(int id)
        {
            var ds = LaySanPham();
            return ds.Find(x => x.MaSanPham == id);
        }

        public List<DungLuong> LayDungLuong(int maSanPham)
        {
            var ds = new List<DungLuong>();
            using (var con = new SqlConnection(cn))
            using (var cmd = new SqlCommand(@"SELECT MaDungLuong, MaSanPham, TenDungLuong
                                              FROM DungLuong WHERE MaSanPham=@id ORDER BY MaDungLuong", con))
            {
                cmd.Parameters.AddWithValue("@id", maSanPham);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ds.Add(new DungLuong {
                            MaDungLuong = rd.GetInt32(0),
                            MaSanPham = rd.IsDBNull(1) ? (int?)null : rd.GetInt32(1),
                            TenDungLuong = rd.IsDBNull(2) ? "" : rd.GetString(2)
                        });
                    }
                }
            }
            return ds;
        }

        public List<TinTuc> LayTinTuc()
        {
            var ds = new List<TinTuc>();
            using (var con = new SqlConnection(cn))
            using (var cmd = new SqlCommand("SELECT MaTin, TieuDe FROM TinTuc ORDER BY MaTin DESC", con))
            {
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ds.Add(new TinTuc {
                            MaTin = rd.GetInt32(0),
                            TieuDe = rd.IsDBNull(1) ? "" : rd.GetString(1)
                        });
                    }
                }
            }
            return ds;
        }
    }
}
