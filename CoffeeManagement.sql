USE [master]
GO
/****** Object:  Database [QuanLiQuanCafe1]    Script Date: 7/23/2020 10:07:16 PM ******/
CREATE DATABASE [QuanLiQuanCafe1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLiQuanCafe1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLiQuanCafe1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLiQuanCafe1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLiQuanCafe1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLiQuanCafe1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLiQuanCafe1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLiQuanCafe1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLiQuanCafe1] SET QUERY_STORE = OFF
GO
USE [QuanLiQuanCafe1]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 7/23/2020 10:07:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/23/2020 10:07:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheck] [date] NULL,
	[idAccount] [int] NOT NULL,
	[idTableFood] [int] NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[Cost] [int] NOT NULL,
	[Discount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFood] [int] NOT NULL,
	[idBill] [int] NOT NULL,
	[Cnt] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryFood] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCategory] [int] NOT NULL,
	[FoodName] [nvarchar](100) NOT NULL,
	[Price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [DisplayName], [UserName], [Password], [Type]) VALUES (1, N'Nguyễn Thanh Hiền', N'Mistakem4', N'13012420314234138112108765216110414524878123', 1)
INSERT [dbo].[Account] ([id], [DisplayName], [UserName], [Password], [Type]) VALUES (2, N'Trần Huyên', N'aka', N'1062015148265751200162442381901670338', 0)
INSERT [dbo].[Account] ([id], [DisplayName], [UserName], [Password], [Type]) VALUES (3, N'Cao Thành Lợi', N'Needgas', N'32454363173212996718614423868288817987', 1)
INSERT [dbo].[Account] ([id], [DisplayName], [UserName], [Password], [Type]) VALUES (8, N'Nguyễn Thành Long', N'slave', N'321140243156111491111562331387837622040', 0)
INSERT [dbo].[Account] ([id], [DisplayName], [UserName], [Password], [Type]) VALUES (9, N'Nguyễn Cồn phương', N'Congphang', N'18519755781075123650184105661918223284185', 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (1, CAST(N'2020-07-06' AS Date), 1, 2, N'Đã thanh toán', 55000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (2, CAST(N'2020-07-06' AS Date), 2, 4, N'Đã thanh toán', 60000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (3, CAST(N'2020-07-06' AS Date), 1, 7, N'Đã thanh toán', 60000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (4, CAST(N'2020-07-06' AS Date), 3, 3, N'Đã thanh toán', 70000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (5, CAST(N'2020-07-06' AS Date), 1, 5, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (6, CAST(N'2020-07-06' AS Date), 2, 8, N'Đã thanh toán', 57000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (7, CAST(N'2020-07-06' AS Date), 1, 10, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (8, CAST(N'2020-07-06' AS Date), 3, 6, N'Đã thanh toán', 140000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (12, CAST(N'2020-07-08' AS Date), 1, 9, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (15, CAST(N'2020-07-08' AS Date), 1, 11, N'Đã thanh toán', 54000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (17, CAST(N'2020-07-08' AS Date), 1, 2, N'Đã thanh toán', 210000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (20, CAST(N'2020-07-09' AS Date), 1, 19, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (22, CAST(N'2020-07-09' AS Date), 1, 14, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (23, CAST(N'2020-07-09' AS Date), 1, 18, N'Đã thanh toán', 20000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (24, CAST(N'2020-07-09' AS Date), 1, 12, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (25, CAST(N'2020-07-09' AS Date), 1, 16, N'Đã thanh toán', 75000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (26, CAST(N'2020-07-09' AS Date), 1, 23, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (27, CAST(N'2020-07-09' AS Date), 1, 19, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (28, CAST(N'2020-07-09' AS Date), 1, 22, N'Đã thanh toán', 60000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (29, CAST(N'2020-07-09' AS Date), 1, 29, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (32, CAST(N'2020-07-09' AS Date), 1, 2, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (33, CAST(N'2020-07-09' AS Date), 1, 15, N'Đã thanh toán', -60000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (34, CAST(N'2020-07-09' AS Date), 1, 18, N'Đã thanh toán', 60000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (35, CAST(N'2020-07-09' AS Date), 1, 23, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (36, CAST(N'2020-07-09' AS Date), 1, 27, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (37, CAST(N'2020-07-09' AS Date), 1, 41, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (38, CAST(N'2020-07-09' AS Date), 1, 32, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (39, CAST(N'2020-07-09' AS Date), 1, 14, N'Đã thanh toán', 102000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (40, CAST(N'2020-07-09' AS Date), 1, 2, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (42, CAST(N'2020-07-09' AS Date), 1, 2, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (43, CAST(N'2020-07-09' AS Date), 1, 2, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (44, CAST(N'2020-07-09' AS Date), 1, 23, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (45, CAST(N'2020-07-09' AS Date), 1, 20, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (46, CAST(N'2020-07-09' AS Date), 1, 14, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (47, CAST(N'2020-07-09' AS Date), 1, 3, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (48, CAST(N'2020-07-09' AS Date), 1, 11, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (49, CAST(N'2020-07-09' AS Date), 1, 10, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (52, CAST(N'2020-07-09' AS Date), 1, 4, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (54, CAST(N'2020-07-09' AS Date), 1, 5, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (68, CAST(N'2020-07-09' AS Date), 1, 19, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (70, CAST(N'2020-07-09' AS Date), 1, 13, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (88, CAST(N'2020-07-09' AS Date), 1, 11, N'Đã thanh toán', 25000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (95, CAST(N'2020-07-10' AS Date), 1, 4, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (96, CAST(N'2020-07-10' AS Date), 1, 9, N'Đã thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (97, CAST(N'2020-07-10' AS Date), 1, 16, N'Đã thanh toán', 105000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (98, CAST(N'2020-07-10' AS Date), 1, 4, N'Đã thanh toán', 90000, 21)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (99, CAST(N'2020-07-10' AS Date), 1, 18, N'Đã thanh toán', 40000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (100, CAST(N'2020-07-10' AS Date), 1, 38, N'Chưa thanh toán', 32000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (101, CAST(N'2020-07-10' AS Date), 1, 20, N'Chưa thanh toán', 10000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (102, CAST(N'2020-07-10' AS Date), 1, 7, N'Đã thanh toán', 75000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (103, CAST(N'2020-07-10' AS Date), 1, 2, N'Đã thanh toán', 40000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (104, CAST(N'2020-07-10' AS Date), 1, 8, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (105, CAST(N'2020-07-10' AS Date), 1, 5, N'Đã thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (106, CAST(N'2020-07-10' AS Date), 1, 6, N'Đã thanh toán', 65000, 50)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (107, CAST(N'2020-07-11' AS Date), 1, 17, N'Đã thanh toán', 60000, 100)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (108, CAST(N'2020-07-13' AS Date), 1, 8, N'Chưa thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (109, CAST(N'2020-07-13' AS Date), 1, 3, N'Đã thanh toán', 10000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (110, CAST(N'2020-07-13' AS Date), 1, 22, N'Chưa thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (111, CAST(N'2020-07-13' AS Date), 1, 14, N'Chưa thanh toán', 55000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (112, CAST(N'2020-07-13' AS Date), 1, 7, N'Chưa thanh toán', 30000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (113, CAST(N'2020-07-15' AS Date), 1, 17, N'Đã thanh toán', 10000, 100)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (115, CAST(N'2020-07-16' AS Date), 1, 17, N'Chưa thanh toán', 45000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (119, CAST(N'2020-07-18' AS Date), 1, 6, N'Đã thanh toán', 15000, 0)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (122, CAST(N'2020-07-18' AS Date), 1, 27, N'Chưa thanh toán', 110000, 20)
INSERT [dbo].[Bill] ([id], [DateCheck], [idAccount], [idTableFood], [Status], [Cost], [Discount]) VALUES (123, CAST(N'2020-07-21' AS Date), 1, 53, N'Đã thanh toán', 30000, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (1, 1, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (2, 3, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (4, 2, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (6, 1, 3, 6)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (7, 3, 2, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (8, 5, 5, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (12, 6, 4, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (13, 2, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (14, 7, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (15, 3, 12, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (16, 4, 15, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (17, 5, 7, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (18, 1, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (19, 2, 2, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (20, 1, 8, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (21, 4, 8, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (23, 6, 8, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (24, 11, 4, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (25, 3, 17, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (26, 9, 17, 6)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (29, 3, 20, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (32, 5, 8, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (34, 3, 26, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (35, 1, 23, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (36, 7, 15, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (37, 3, 24, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (38, 3, 27, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (39, 6, 28, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (40, 6, 22, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (41, 6, 29, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (50, 3, 32, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (51, 9, 6, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (52, 2, 33, -4)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (53, 2, 34, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (54, 2, 35, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (55, 2, 36, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (56, 2, 37, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (57, 6, 38, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (58, 6, 39, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (59, 5, 39, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (60, 7, 39, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (61, 3, 40, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (62, 3, 42, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (63, 3, 43, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (64, 3, 28, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (65, 3, 25, 5)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (66, 3, 34, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (67, 3, 44, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (68, 3, 45, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (69, 4, 46, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (70, 5, 47, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (71, 3, 48, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (72, 3, 49, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (74, 3, 52, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (76, 3, 54, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (79, 1, 68, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (80, 3, 70, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (81, 3, 88, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (84, 3, 95, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (85, 3, 96, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (86, 3, 97, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (87, 4, 97, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (88, 5, 97, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (89, 1, 88, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (90, 1, 98, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (91, 12, 98, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (92, 9, 98, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (93, 1, 99, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (94, 1, 100, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (95, 7, 100, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (96, 1, 101, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (97, 6, 102, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (98, 1, 103, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (99, 4, 103, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (100, 6, 103, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (101, 2, 104, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (102, 2, 99, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (103, 6, 99, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (104, 2, 102, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (105, 3, 98, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (106, 4, 98, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (107, 3, 105, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (108, 3, 106, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (109, 1, 106, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (110, 5, 106, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (111, 6, 107, 4)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (112, 3, 108, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (113, 1, 109, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (114, 6, 110, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (115, 3, 111, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (116, 6, 112, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (117, 1, 113, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (119, 1, 115, 3)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (122, 3, 119, 1)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (125, 3, 122, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (126, 11, 122, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (127, 4, 122, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (128, 48, 111, 2)
INSERT [dbo].[BillInfo] ([id], [idFood], [idBill], [Cnt]) VALUES (129, 3, 123, 2)
GO
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [CategoryFood]) VALUES (1, N'Nước ép')
INSERT [dbo].[Category] ([id], [CategoryFood]) VALUES (2, N'Cafe')
INSERT [dbo].[Category] ([id], [CategoryFood]) VALUES (3, N'Trà')
INSERT [dbo].[Category] ([id], [CategoryFood]) VALUES (4, N'Bánh')
INSERT [dbo].[Category] ([id], [CategoryFood]) VALUES (5, N'Chocolate')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (1, 2, N'Cafe đen', 15000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (2, 2, N'Cafe sữa', 15000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (3, 1, N'Nước ép thơm', 15000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (4, 1, N'Nước chanh day', 20000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (5, 3, N'Trà đào', 15000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (6, 3, N'Trà vải', 15000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (7, 3, N'Trà chanh', 12000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (8, 4, N'Bánh plan', 10000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (9, 4, N'Bánh táo', 30000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (11, 4, N'Bánh sừng bò', 20000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (12, 4, N'Bánh phô mai', 20000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (47, 1, N'Nước ép nho', 20000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (48, 2, N'Nước ép dưa hấu', 20000)
INSERT [dbo].[Food] ([id], [idCategory], [FoodName], [Price]) VALUES (50, 3, N'Trà táo', 25000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (2, 10, N'Bàn 0', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (3, 5, N'Bàn 1', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (4, 10, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (5, 10, N'Bàn 3', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (6, 10, N'Bàn 4', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (7, 10, N'Bàn 5', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (8, 10, N'Bàn 6', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (9, 10, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (10, 10, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (11, 10, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (12, 10, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (13, 10, N'Bàn 11', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (14, 10, N'Bàn 12', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (15, 10, N'Bàn 13', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (16, 10, N'Bàn 14', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (17, 10, N'Bàn 15', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (18, 10, N'Bàn 16', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (19, 10, N'Bàn 17', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (20, 10, N'Bàn 18', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (21, 10, N'Bàn 19', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (22, 10, N'Bàn 20', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (23, 10, N'Bàn 21', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (24, 10, N'Bàn 22', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (25, 10, N'Bàn 23', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (26, 10, N'Bàn 24', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (27, 10, N'Bàn 25', N'Có khách')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (28, 10, N'Bàn 26', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (29, 10, N'Bàn 27', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (30, 10, N'Bàn 28', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (31, 10, N'Bàn 29', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (32, 10, N'Bàn 30', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (33, 10, N'Bàn 31', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (34, 10, N'Bàn 32', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (35, 10, N'Bàn 33', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (36, 10, N'Bàn 34', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (37, 10, N'Bàn 35', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (38, 10, N'Bàn 36', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (39, 10, N'Bàn 37', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (40, 10, N'Bàn 38', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (41, 10, N'Bàn 39', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (42, 10, N'Bàn 40', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (43, 10, N'Bàn 41', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (44, 10, N'Bàn 42', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (45, 10, N'Bàn 43', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (46, 10, N'Bàn 44', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (47, 10, N'Bàn 45', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (48, 10, N'Bàn 46', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (49, 10, N'Bàn 47', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (50, 10, N'Bàn 48', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (51, 10, N'Bàn 49', N'Trống')
INSERT [dbo].[TableFood] ([id], [Capacity], [Name], [Status]) VALUES (53, 2, N'Bàn 50', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheck]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (N'Chưa thanh toán') FOR [Status]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [Cnt]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (N'Chưa có tên ') FOR [CategoryFood]
GO
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [Status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idAccount])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTableFood])
REFERENCES [dbo].[TableFood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Category] ([id])
GO
/****** Object:  StoredProcedure [dbo].[UPS_CheckFoodNameAvailable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPS_CheckFoodNameAvailable]
@id int,
@name nvarchar(100)
as
 begin
 select count(*) from Food where @id != id and @name = Food.FoodName
 end
GO
/****** Object:  StoredProcedure [dbo].[UPS_CheckTableNameAvailable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPS_CheckTableNameAvailable]
@id int,
@Name nvarchar(100)
as begin
	select count(*) from TableFood where id != @id and Name = @Name
end
GO
/****** Object:  StoredProcedure [dbo].[UPS_updatefood]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[UPS_updatefood]
@id int,
@foodname nvarchar(100),
@idcategory int,
@price int


as begin
 update Food 
 set FoodName = @foodname , idCategory = @idcategory , Price = @price
 where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[UPS_UpdateStatus]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UPS_UpdateStatus]
as
begin
delete Bill  where   (select count(*) from BillInfo where Bill.id = BillInfo.idBill) = 0 ;
update TableFood 
set Status = N'Trống'
where (select count(*) from Bill where Bill.idTableFood = TableFood.id and Bill.Status = N'Chưa thanh toán') = 0
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddBill]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_AddBill]
@IdAccount int,
@IdTableFood int,
@Discount int
as
begin 
	insert into Bill (idAccount ,idTableFood,discount)
	values(@IdAccount,@IdTableFood,@Discount)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddBillInfo]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_AddBillInfo]
@IdFood int,
@IdBill int,
@cnt int
as
begin
insert into billinfo(idBill,idFood,Cnt)
values (@IdBill,@IdFood,@cnt)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddFoodtoBill]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[USP_AddFoodtoBill]
@IdFood int ,
@IdBill int,
@cnt int
as 
begin 
	declare @FindFood int ;
	set @FindFood = (select count(*) from BillInfo where BillInfo.idBill = @IdBill and BillInfo.idFood = @IdFood) ;
	if @FindFood > 0
	begin
		update BillInfo
		set Cnt = Cnt +@cnt where BillInfo.idBill = @IdBill and BillInfo.idFood = @IdFood;		
	end		
	else
		begin
		if @cnt > 0
		exec USP_AddBillInfo @idfood , @idbill , @cnt ;
		end
	if (select max(cnt) from BillInfo where BillInfo.idBill = @IdBill and BillInfo.idFood = @IdFood) <= 0
			delete from BillInfo  where BillInfo.idBill = @IdBill and BillInfo.idFood = @IdFood;	
	if(select count(*) from BillInfo where  BillInfo.idBill = @IdBill ) = 0
		delete from Bill where Bill.id = @IdBill
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ChangeTable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_ChangeTable]
@NewTableId int,
@BillID int
as begin
	update  bill
	set bill.idTableFood = @NewTableId
	where bill.id = @BillID ;
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckCategoryAvailable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_CheckCategoryAvailable]
@id int ,
@name nvarchar(100)
as begin
	select count(*) from category where id!=@id  and categoryfood = @name
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckUserNameAvailable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_CheckUserNameAvailable]
@id int,
@username nvarchar(100)
as
begin
	select count(*) from Account 
	where id != @id and UserName = @username

end
GO
/****** Object:  StoredProcedure [dbo].[USP_EditAccount]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_EditAccount]
@Id  nvarchar(100),
@UserName nvarchar(100),
@DisplayName nvarchar(100),
@type int
as begin
	Update Account
	set  username = @UserName ,displayname = @displayname , type = @type
	where @id = id

end
GO
/****** Object:  StoredProcedure [dbo].[USP_EditTable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_EditTable]
@id int,
@Capacity int,
@name nvarchar(100),
@status nvarchar(100)
as begin
	update TableFood 
	set Capacity=@Capacity , Name = @name , Status = @status
	where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBill]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetBill]
as begin
 select * from bill
 end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBillByDate]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetBillByDate]
@DateStart date,
@DateEnd date
as
begin

 select  datecheck as [Ngày], tablefood.name as[Tên Bàn],Account.DisplayName as [Tên nhân viên], discount as [Giảm giá (%)] ,cost [Giá tri đơn hàng trước giảm giá] from bill,tablefood,Account
 where datecheck >= @DateStart and DateCheck <= @DateEnd and bill.idtablefood = TableFood.id and bill.Status = N'Đã thanh toán' and Bill.idAccount = Account.id
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetBillByDateEn]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[USP_GetBillByDateEn]
@DateStart date,
@DateEnd date
as
begin

 select  datecheck , tablefood.name ,Account.DisplayName, discount ,cost from bill,tablefood,Account
 where datecheck >= @DateStart and DateCheck <= @DateEnd and bill.idtablefood = TableFood.id and bill.Status = N'Đã thanh toán' and Bill.idAccount = Account.id
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCountBillByDate]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetCountBillByDate]
@DateStart Date,
@DateEnd Date
as begin
select count(*) from bill,tablefood,Account
 where datecheck >=@DateStart and DateCheck <=@DateEnd and bill.idtablefood = TableFood.id and bill.Status = N'Đã thanh toán' and Bill.idAccount = Account.id
 end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDataTableAccountByName]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetDataTableAccountByName]
@Name nvarchar(100)
as
begin
	select  id ,displayname , username , type  from Account 
	where  dbo.fuConvertToUnsign1(DisplayName) like dbo.fuConvertToUnsign1(('%' + @Name +'%'))
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDataTableFoodByName]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetDataTableFoodByName]
 @Name nvarchar(100)
 as begin 
  select f.id, f.FoodName as[Tên món] , c.CategoryFood as [Danh mục], f.Price as [Giá] from food as f , Category as c where c.id = f.idCategory and dbo.fuConvertToUnsign1(f.FoodName) like dbo.fuConvertToUnsign1(('%' + @Name +'%'))
  end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateAndPage]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListBillByDateAndPage]

@DateStart Date,
@DateEnd Date,
@Page int
as begin
select    datecheck as [Ngày], tablefood.name as[Tên Bàn],Account.DisplayName as [Tên nhân viên], discount as [Giảm giá (%)] ,cost [Giá tri đơn hàng trước giảm giá] from bill,tablefood,Account
 where datecheck >=@DateStart and DateCheck <=@DateEnd and bill.idtablefood = TableFood.id and bill.Status = N'Đã thanh toán' and Bill.idAccount = Account.id order by Bill.id offset (@Page*15-15) rows fetch next 15 rows only
 end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListCategoryByName]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_GetListCategoryByName]
@Name nvarchar(100)
as
begin
	select * from Category where  dbo.fuConvertToUnsign1(CategoryFood) like  dbo.fuConvertToUnsign1(('%' + @Name +'%'))
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListTableByName]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetListTableByName]
@Name nvarchar(100)
as
begin
	select * from TableFood where  dbo.fuConvertToUnsign1(Name) like  dbo.fuConvertToUnsign1(('%' + @Name +'%'))
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertAccount]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertAccount]
@DisplayName nvarchar(100),
@UserName nvarchar(100),

@PassWord nvarchar(100),
@type int
as begin
	insert into Account
	values (@DisplayName, @username, @PassWord,@Type)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertTable]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_InsertTable]
@Capacity int,
@name nvarchar(100),
@status nvarchar(100)
as begin
	insert into TableFood values(@Capacity,@name,@status)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@username nvarchar(100), @password nvarchar(100)
as
begin
Select * from Account
where account.UserName = @username and account.Password = @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_pay]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_pay]
@IdBill int
as 
begin
	update  bill 
	set bill.Status = N'Đã thanh toán'
	where bill.id = @IdBill
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ResetPassWord]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_ResetPassWord]
@id int,
@DefaultPassWord nvarchar(100)
as begin
	Update Account
	set Password = @defaultPassWord
	where id = @id
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 7/23/2020 10:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_UpdateAccount] 
@Id int,
@DisplayName nvarchar(100),
@UserName nvarchar(100),
@PassWord nvarchar(100),
@NewPassWord nvarchar(100),
@Type int 
as begin
	if (select count(*) from Account where @Id = id and @PassWord = Password) > 0
	begin
		if @NewPassWord = null or @NewPassWord = ''
		update Account set UserName = @UserName , DisplayName = @DisplayName where @Id = id;
		else
		update Account set UserName = @UserName,Type = @Type, PassWord = @NewPassWord, DisplayName = @DisplayName where @Id = id;



	end
end
GO
USE [master]
GO
ALTER DATABASE [QuanLiQuanCafe1] SET  READ_WRITE 
GO
