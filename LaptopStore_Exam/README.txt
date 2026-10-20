LAPTOP STORE - BAI KIEM TRA WEB

1. Tạo project ASP.NET Web Application (.NET Framework), chọn MVC, .NET Framework 4.8.
2. Đặt tên project: LaptopStore.
3. Chép các file trong thư mục này vào project tương ứng.
4. Cài/restore NuGet packages từ packages.config.
5. Tạo thư mục Images và chép ảnh sản phẩm vào đó.
6. Web.config đang dùng:
   Data Source=.;Initial Catalog=LaptopStore;Integrated Security=True
   Nếu SQL Server của máy dùng instance khác, sửa Data Source.
   Ví dụ theo máy trong ảnh đề: Data Source=A204PC17ACSSQL22
7. Trong HomeController.cs sửa:
   ViewBag.MaSo = "MÃ SINH VIÊN CỦA BẠN";
   ViewBag.HoTen = "HỌ TÊN CỦA BẠN";
8. Chạy SQL LaptopStore trước rồi F5.
9. Trang chủ: /Home/Index
   Shop: /SanPham/Index
   Chi tiết: /SanPham/Details/1

Lưu ý:
- Code dùng ADO.NET, không cần Entity Framework.
- Bảng được dùng theo đúng schema nhìn thấy trong ảnh:
  DanhMuc(MaDanhMuc, TenDanhMuc)
  SanPham(MaSanPham, MaDanhMuc, TenSanPham, MoTa, TinhTrang, Gia, HinhAnh, CauHinh, UuDiem)
  DungLuong(MaDungLuong, MaSanPham, TenDungLuong)
  TinTuc(MaTin, TieuDe)
