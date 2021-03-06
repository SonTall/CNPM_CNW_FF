USE [FastFoodManagement]
GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[MaChuDe] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](50) NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaChuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaHoaDon] [int] NOT NULL,
	[MaMonAn] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_DONHANG] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiamGia]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiamGia](
	[MaKhuyenMai] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
 CONSTRAINT [PK_HOADON_KHUYENMAI] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonThanhToan]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaKhachVangLai] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[ThoiGian] [datetime] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [nchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachVangLai]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachVangLai](
	[MaKhachVangLai] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KhachVangLai] PRIMARY KEY CLUSTERED 
(
	[MaKhachVangLai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKhuyenMai] [int] IDENTITY(1,1) NOT NULL,
	[MoTa] [text] NULL,
	[ThoiGianBatDau] [datetime] NULL,
	[ThoiGianKetThuc] [datetime] NULL,
	[GiaTri] [float] NULL,
 CONSTRAINT [PK_KHUYENMAI] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAn] [int] NOT NULL,
	[MaChuDe] [int] NOT NULL,
	[TenMonAn] [nvarchar](50) NULL,
	[DonGia] [nvarchar](50) NULL,
	[HinhAnh] [nvarchar](50) NULL,
	[GhiChu] [text] NULL,
 CONSTRAINT [PK_MONAN] PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[SoDienThoai] [varchar](11) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/15/2018 6:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[ThoiGianTao] [date] NULL,
	[LoaiTaiKhoan] [int] NULL,
	[HinhAnh] [nvarchar](50) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (1, N'banh', N'cac loai banh')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (2, N'nuoc ngot', N'nuoc ngot haha')
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (1, 2)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (1, 6)
SET IDENTITY_INSERT [dbo].[HoaDonThanhToan] ON 

INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (2, 1, 1, NULL, N'123', CAST(0x00009AF200000000 AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (3, 1, 1, NULL, N'456', CAST(0x0000A8BB00000000 AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (4, 1, 1, NULL, N'dgfd', CAST(0x0000A3C000000000 AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (5, 1, 1, NULL, N'g', CAST(0x0000A3C000000000 AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (6, 1, 1, NULL, N'24s sss', CAST(0x0000A8D800000000 AS DateTime))
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [MaKhachVangLai], [GhiChu], [ThoiGian]) VALUES (7, 1, 1, NULL, N'abc', CAST(0x00009AF200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDonThanhToan] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email], [TenTaiKhoan], [MatKhau], [HinhAnh]) VALUES (1, N'cao huy tuan', N'ha noi', N'0915676438', N'123@gmail.com', N'123', N'123', NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [GiaTri]) VALUES (1, N'123456', CAST(0x0000A85B00000000 AS DateTime), CAST(0x0000A85C00000000 AS DateTime), 20)
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (1, 1, N'pizza 1', N'50000', N'img_1.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (2, 2, N'coca', N'15000', N'img_2.jpg', N'nuoc ngot ')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (3, 1, N'pizza 2', N'20000', N'img_3.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (4, 1, N'pizza 3', N'20000', N'img_4.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (5, 1, N'pizza 4', N'20000', N'img_5.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (6, 1, N'pizza 5', NULL, N'img_6.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (7, 1, N'pizza 6', NULL, N'img_7.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (8, 1, N'pizza 7', NULL, N'img_8.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (9, 1, N'pizza 8', NULL, N'img_9.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (10, 1, N'pizza 9', NULL, N'img_10.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (11, 1, N'pizza 10', NULL, N'img_11.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (12, 1, N'pizza 11', NULL, N'img_12.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (13, 1, N'pizza 12', NULL, N'img_13.jpg', NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai]) VALUES (1, N'cao xuan son ', CAST(0xB4200B00 AS Date), N'1234567890')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [ThoiGianTao], [LoaiTaiKhoan], [HinhAnh]) VALUES (1, N'caoxuanson', N'123456', CAST(0x2F3E0B00 AS Date), 2, NULL)
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_HOADON] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DONHANG_HOADON]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_MONAN] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DONHANG_MONAN]
GO
ALTER TABLE [dbo].[GiamGia]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHUYENMAI_HOADON] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[GiamGia] CHECK CONSTRAINT [FK_HOADON_KHUYENMAI_HOADON]
GO
ALTER TABLE [dbo].[GiamGia]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHUYENMAI_KHUYENMAI] FOREIGN KEY([MaKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([MaKhuyenMai])
GO
ALTER TABLE [dbo].[GiamGia] CHECK CONSTRAINT [FK_HOADON_KHUYENMAI_KHUYENMAI]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_KhachVangLai] FOREIGN KEY([MaKhachVangLai])
REFERENCES [dbo].[KhachVangLai] ([MaKhachVangLai])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_KhachVangLai]
GO
ALTER TABLE [dbo].[HoaDonThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonThanhToan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonThanhToan] CHECK CONSTRAINT [FK_HoaDonThanhToan_NhanVien]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_ChuDe]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_TAIKHOAN] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NHANVIEN_TAIKHOAN]
GO
