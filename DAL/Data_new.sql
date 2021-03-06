USE [FastFoodManagement]
GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 6/26/2018 11:53:10 PM ******/
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
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/26/2018 11:53:11 PM ******/
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
/****** Object:  Table [dbo].[GiamGia]    Script Date: 6/26/2018 11:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiamGia](
	[MaKhuyenMai] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[ApDung] [bit] NOT NULL,
 CONSTRAINT [PK_HOADON_KHUYENMAI] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonThanhToan]    Script Date: 6/26/2018 11:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaKhachVangLai] [int] NULL,
	[ThanhToan] [bit] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[ThoiGianDatHang] [datetime] NULL,
	[ThoiGianThanhToan] [datetime] NULL,
	[GiaoHang] [bit] NOT NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/26/2018 11:53:11 PM ******/
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
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachVangLai]    Script Date: 6/26/2018 11:53:11 PM ******/
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
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 6/26/2018 11:53:11 PM ******/
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
/****** Object:  Table [dbo].[MonAn]    Script Date: 6/26/2018 11:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAn] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/26/2018 11:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [datetime] NULL,
	[SoDienThoai] [varchar](11) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/26/2018 11:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaNhanVien] [int] NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[ThoiGianTao] [datetime] NULL,
	[LoaiTaiKhoan] [int] NULL,
	[HinhAnh] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (1, N'banh', N'cac loai banh')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (2, N'nuoc ngot', N'nuoc ngot haha')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (5, N'banh qua hah', N'hahaha')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (6, N'bun', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (7, N'1', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (8, N'2', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (9, N'3', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (10, N'4', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (11, N'5', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (12, N'7', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (13, N'8', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (14, N'9', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (15, N'10', NULL)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (16, N'banhhhhhhh', N'WorldCup2018')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (17, N'keooooooooooo', N'hahaha')
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (10, 1, 10)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (11, 1, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (11, 3, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (12, 1, 2)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (12, 3, 2)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (13, 1, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (13, 3, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (14, 1, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (14, 2, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (15, 1, 1)
INSERT [dbo].[DonHang] ([MaHoaDon], [MaMonAn], [SoLuong]) VALUES (16, 1, 2)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon], [ApDung]) VALUES (4, 6, 1)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon], [ApDung]) VALUES (4, 7, 0)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon], [ApDung]) VALUES (4, 10, 0)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon], [ApDung]) VALUES (5, 10, 0)
SET IDENTITY_INSERT [dbo].[HoaDonThanhToan] ON 

INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (6, NULL, NULL, 1, N'dattructep', CAST(0x0000A90A0174D35C AS DateTime), CAST(0x0000A90A0174D35C AS DateTime), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (7, NULL, NULL, 1, N'hoa don truc tiep', CAST(0x0000A90800D9CDD0 AS DateTime), CAST(0x0000A90800D9CDD0 AS DateTime), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (8, NULL, NULL, 1, N'trực tiếp', CAST(0x0000A90A0174F7B0 AS DateTime), CAST(0x0000A90A0174F7B0 AS DateTime), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (10, NULL, NULL, 1, N'hello', CAST(0x0000A90A016F38FC AS DateTime), CAST(0x0000A90A016F38FC AS DateTime), 1)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (11, NULL, 8, 0, NULL, CAST(0x0000A909017E1296 AS DateTime), NULL, 0)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (12, 10, NULL, 0, NULL, CAST(0x0000A909018B1885 AS DateTime), NULL, 0)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (13, 10, NULL, 0, NULL, CAST(0x0000A90A0000CA69 AS DateTime), NULL, 0)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (14, 10, NULL, 0, NULL, CAST(0x0000A90A0001494E AS DateTime), NULL, 0)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (15, 10, NULL, 0, NULL, CAST(0x0000A90A0002682A AS DateTime), NULL, 0)
INSERT [dbo].[HoaDonThanhToan] ([MaHoaDon], [MaKhachHang], [MaKhachVangLai], [ThanhToan], [GhiChu], [ThoiGianDatHang], [ThoiGianThanhToan], [GiaoHang]) VALUES (16, NULL, 9, 0, NULL, CAST(0x0000A90B01762542 AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[HoaDonThanhToan] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (2, N'sonnnn', N'ha noi', N'1234321   ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (3, N'sonnnn', N'ha noiii', N'1234321   ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (4, N'sonnnn', N'11', N'123       ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (5, N'sonnnn', N'11', N'1234321   ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (8, N'cao xuan son', N'hà nội', N'1234      ', N'@soncao')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (9, N'sonnnn', N'ha noi', N'0915676438', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (10, N'ten khach hang', N'ha tay', N'1         ', N'123@gmail.com')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (11, N'cao huy tuan', N'11', N'1         ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (13, N'ten khach hang', N'11', N'0915676438', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (15, N'sonnnn', N'ha noi', N'1234321   ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (16, N'sonnnn', N'11', N'1234321   ', NULL)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (17, N'sonnnn', N'11', N'1234321   ', N'soncao@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (18, N'cao cao cao', N'ha tay', N'0946618745', N'@soncao123')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (19, N'hey', N'hey', N'0915676438', N'hey@')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[KhachVangLai] ON 

INSERT [dbo].[KhachVangLai] ([MaKhachVangLai], [HoTen], [DiaChi], [SoDienThoai]) VALUES (7, N'cao xuan son', N'ha noiii', N'1234321')
INSERT [dbo].[KhachVangLai] ([MaKhachVangLai], [HoTen], [DiaChi], [SoDienThoai]) VALUES (8, N'cao xuan son', N'ha noi', N'0915676438')
INSERT [dbo].[KhachVangLai] ([MaKhachVangLai], [HoTen], [DiaChi], [SoDienThoai]) VALUES (9, N'ahehehh', N'ha noiii', N'0915676438')
SET IDENTITY_INSERT [dbo].[KhachVangLai] OFF
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [GiaTri]) VALUES (4, N'WorldCup2018', CAST(0x0000A90901720ADC AS DateTime), CAST(0x0000A92901720ADC AS DateTime), 40)
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [GiaTri]) VALUES (5, N'hahaha', CAST(0x0000A90800AB4488 AS DateTime), CAST(0x0000A90800AB4488 AS DateTime), 11)
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [GiaTri]) VALUES (6, NULL, CAST(0x0000A90800AB5040 AS DateTime), CAST(0x0000A90801501BC0 AS DateTime), 20)
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [MoTa], [ThoiGianBatDau], [ThoiGianKetThuc], [GiaTri]) VALUES (7, N'hahaha', CAST(0x0000A909017226FC AS DateTime), CAST(0x0000A929017226FC AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
SET IDENTITY_INSERT [dbo].[MonAn] ON 

INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (1, 1, N'pizzaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1', N'50000', N'img_1.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (2, 2, N'coca', N'15000', N'img_2.jpg', N'nuoc ngot ')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (3, 1, N'pizza 2', N'15000', N'img_3.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (4, 1, N'pizza 3', N'20000', N'img_4.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (5, 1, N'pizza 4', N'20000', N'img_5.jpg', N'aab')
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (6, 1, N'pizza 5', NULL, N'img_6.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (7, 1, N'pizza 6', NULL, N'img_7.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (9, 1, N'pizza 8', NULL, N'img_9.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (11, 1, N'pizza 10', NULL, N'img_11.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (12, 1, N'pizza 11', NULL, N'img_12.jpg', NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [MaChuDe], [TenMonAn], [DonGia], [HinhAnh], [GhiChu]) VALUES (15, 1, N'gato', N'75000', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [SoDienThoai], [DiaChi], [Email]) VALUES (2, N'cao xuan haha', 1, CAST(0x0000A90A0184D7C0 AS DateTime), N'1234321', N'11', N'soncao@')
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [SoDienThoai], [DiaChi], [Email]) VALUES (3, N'son1a a', 0, CAST(0x0000A90B017FD48C AS DateTime), N'0915676438', N'ha noi', N'soncao@')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaKhachHang], [MaNhanVien], [TenTaiKhoan], [MatKhau], [ThoiGianTao], [LoaiTaiKhoan], [HinhAnh]) VALUES (17, 8, NULL, N'khachhang', N'fcea920f7412b5da7be0cf42b8c93759', CAST(0x0000A90A015B3334 AS DateTime), 0, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaKhachHang], [MaNhanVien], [TenTaiKhoan], [MatKhau], [ThoiGianTao], [LoaiTaiKhoan], [HinhAnh]) VALUES (18, NULL, 2, N'soncao', N'fcea920f7412b5da7be0cf42b8c93759', CAST(0x0000A90A015D9368 AS DateTime), 0, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaKhachHang], [MaNhanVien], [TenTaiKhoan], [MatKhau], [ThoiGianTao], [LoaiTaiKhoan], [HinhAnh]) VALUES (19, 19, NULL, N'hey', N'25d55ad283aa400af464c76d713c07ad', CAST(0x0000A90B0141AA1B AS DateTime), 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaKhachHang], [MaNhanVien], [TenTaiKhoan], [MatKhau], [ThoiGianTao], [LoaiTaiKhoan], [HinhAnh]) VALUES (20, NULL, 3, N'123', N'25d55ad283aa400af464c76d713c07ad', CAST(0x0000A90B0176DBAC AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
ALTER TABLE [dbo].[KhuyenMai] ADD  CONSTRAINT [DF_ThoiGianBatDau]  DEFAULT (getdate()) FOR [ThoiGianBatDau]
GO
ALTER TABLE [dbo].[KhuyenMai] ADD  CONSTRAINT [DF_ThoiGianKetThuc]  DEFAULT (getdate()) FOR [ThoiGianKetThuc]
GO
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
ALTER TABLE [dbo].[GiamGia]  WITH CHECK ADD  CONSTRAINT [FK_GiamGia_HoaDonThanhToan] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[GiamGia] CHECK CONSTRAINT [FK_GiamGia_HoaDonThanhToan]
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
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_ChuDe]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_KhachHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
