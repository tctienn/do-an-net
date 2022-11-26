
create database do_an_net
go
use do_an_net
go
CREATE TABLE [sanpham] (
  [mathuoc] int IDENTITY(1,1) PRIMARY KEY,
  [lo_lohang] int,
  [tenthuoc] nvarchar(255),
  [id_loaisp] int,
  [ngaynhap] date,
  [manv_nhanvien] int,
  [ngayhethan] date,
  [soluong] int,
  [gia] float,
  [deleteed] int
)
GO

CREATE TABLE [loaisp] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [loai] nvarchar(255)
)
GO

CREATE TABLE [lohang] (
  [lo] int IDENTITY(1,1) PRIMARY KEY,
  [ngaynhap] date,
  [manv_nhanvien] int,
  [nhacungcap] nvarchar(255)
)
GO

CREATE TABLE [nhanvien] (
  [manv] int IDENTITY(1,1) PRIMARY KEY,
  [tennv] nvarchar(255),
  [diachi] nvarchar(255),
  [gioitinh] nvarchar(255),
  [sdt] int,
  [namsinh] int,
  [trangthai] int
)
GO

CREATE TABLE [thongkehuy] (
  [sophieu] int IDENTITY(1,1) PRIMARY KEY,
  [id_lohang] int,
  [mathuoc_sanpham] int,
  [ngayhethan] date,
  [ngayhuy] date,
  [manv_nhanvien] int,
  [soluong] int
)
GO

CREATE TABLE [hoadon] (
  [mahd] bigint PRIMARY KEY,
  [id_khachhang] bigint,
  [ngaytao] date,
  [nhanvien] nvarchar(255),
  [tongtien] float
)
GO

CREATE TABLE [khachhang] (
  [id] bigint PRIMARY KEY,
  [ten] nvarchar(255),
  [sdt] int,
  [mahd_hoadon] int
)
GO

CREATE TABLE [sanphamhoadon] (
  [mahd_hoadon] bigint,
  [mathuoc_sanpham] int,
  [tenthuoc] nvarchar(255),
  [gia] float,
  [soluong] int
)
GO

CREATE TABLE [taikhoan] (
  -- [id] int IDENTITY(1,1),
  [mk] nvarchar(255) ,
  [tk] nvarchar(255)  PRIMARY KEY,
  [cap] int
)
GO

ALTER TABLE [sanpham] ADD FOREIGN KEY ([manv_nhanvien]) REFERENCES [nhanvien] ([manv])
GO

ALTER TABLE [sanpham] ADD FOREIGN KEY ([lo_lohang]) REFERENCES [lohang] ([lo])
GO

ALTER TABLE [sanpham] ADD FOREIGN KEY ([id_loaisp]) REFERENCES [loaisp] ([id])
GO

ALTER TABLE [thongkehuy] ADD FOREIGN KEY ([id_lohang]) REFERENCES [lohang] ([lo])
go
ALTER TABLE [thongkehuy] ADD FOREIGN KEY ([manv_nhanvien]) REFERENCES [nhanvien] ([manv])
GO

ALTER TABLE [hoadon] ADD FOREIGN KEY ([id_khachhang]) REFERENCES [khachhang] ([id])
GO

ALTER TABLE [lohang] ADD FOREIGN KEY ([manv_nhanvien]) REFERENCES [nhanvien] ([manv])
GO

ALTER TABLE [sanphamhoadon] ADD FOREIGN KEY ([mahd_hoadon]) REFERENCES [hoadon] ([mahd])
GO

ALTER TABLE [sanphamhoadon] ADD FOREIGN KEY ([mathuoc_sanpham]) REFERENCES [sanpham] ([mathuoc])
GO


go
insert into nhanvien(tennv,diachi,gioitinh,sdt,namsinh,trangthai)
values ('nhanvien1','dia chi1','nam','1','1','1'),
('nhanvien2','dia chi2','nam','22','2','1'),
('nhanvien3','dia chi3','nam','333','3','1'),
('nhanvien4','dia chi4','nam','44','4','0')
go
insert into lohang(ngaynhap,manv_nhanvien,nhacungcap)
values ('1/1/1','1','1'),
('1/1/1','2','2'),
('1/1/1','3','3')
go
insert into loaisp(loai)
values ('loai 1'),
('loai 2'),
('loai 3')
go
insert into sanpham(lo_lohang,tenthuoc,id_loaisp,ngaynhap,manv_nhanvien,ngayhethan,soluong,gia,deleteed)
values ('1','thuoc 1','1','1/1/1','1','1/1/1','4','10000','1'),
('2','thuoc 2','2','1/1/1','2','1/1/1','10','20000','1'),
('3','thuoc 3','3','1/1/1','1','1/1/1','11','100000','1')


go 
insert into taikhoan --mk : 1
values ('C4CA4238A0B923820DCC509A6F75849B','admin','1');