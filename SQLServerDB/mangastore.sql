USE [master]
GO
/****** Object:  Database [mangastore]    Script Date: 19/12/2023 22:23:06 ******/
CREATE DATABASE [mangastore]
GO
ALTER DATABASE [mangastore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mangastore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mangastore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mangastore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mangastore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mangastore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mangastore] SET ARITHABORT OFF 
GO
ALTER DATABASE [mangastore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mangastore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mangastore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mangastore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mangastore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mangastore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mangastore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mangastore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mangastore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mangastore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mangastore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mangastore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mangastore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mangastore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mangastore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mangastore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mangastore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mangastore] SET RECOVERY FULL 
GO
ALTER DATABASE [mangastore] SET  MULTI_USER 
GO
ALTER DATABASE [mangastore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mangastore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mangastore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mangastore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mangastore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mangastore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'mangastore', N'ON'
GO
ALTER DATABASE [mangastore] SET QUERY_STORE = ON
GO
ALTER DATABASE [mangastore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [mangastore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartDetails]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetails](
	[cart_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_CartDetails] PRIMARY KEY CLUSTERED 
(
	[cart_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [bigint] NOT NULL,
	[total_price] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](10) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[province] [int] NOT NULL,
	[status] [int] NOT NULL,
	[payment_method] [int] NOT NULL,
	[total_order] [bigint] NOT NULL,
	[delivery_fee] [bigint] NOT NULL,
	[total_price] [bigint] NOT NULL,
	[order_date] [datetime2](7) NOT NULL,
	[delivery_date] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[slug] [nvarchar](255) NOT NULL,
	[image] [nvarchar](max) NOT NULL,
	[author] [nvarchar](100) NOT NULL,
	[author_slug] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[list_price] [bigint] NOT NULL,
	[price] [bigint] NOT NULL,
	[discount_rate] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[publish_year] [int] NOT NULL,
	[size] [nvarchar](30) NOT NULL,
	[collection] [nvarchar](255) NULL,
	[collection_slug] [nvarchar](255) NULL,
	[category] [int] NOT NULL,
	[image_uuid] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sample]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sample](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sample] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19/12/2023 22:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[gender] [int] NOT NULL,
	[phone] [nvarchar](10) NULL,
	[address] [nvarchar](max) NULL,
	[province] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221202160114_create_products_table', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221210035538_update_collection_size', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221213083013_Create_user_and_account_table', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221213083413_edit_user_table', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221213144432_alter_user_name_size', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216044139_create_cart_and_cart_detail_model', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221217145835_create_sample_table', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221220165633_create_order_and_order_detail', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221221111857_alter_orders_table_deliverydate_nullable', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221221121349_alter_foreign_key_table_order', N'6.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707091949_add_image_uuid_products_table', N'6.0.11')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([id], [username], [password], [email], [role]) VALUES (2, N'nhan2908', N'$2a$11$1h5fGQGkhrMTcF0yFP6In.nRtVvWp1xdAq2i3h5SrTpDZRnhruVKK', N'20520667@gm.uit.edu.vn', 0)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([id], [user_id]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
INSERT [dbo].[OrderDetails] ([order_id], [product_id], [quantity], [price], [total_price]) VALUES (21, 22, 3, 121500, 364500)
INSERT [dbo].[OrderDetails] ([order_id], [product_id], [quantity], [price], [total_price]) VALUES (22, 22, 3, 121500, 364500)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (17, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 0, 3, 364500, 20000, 384500, CAST(N'2023-11-24T15:47:28.5681815' AS DateTime2), NULL)
INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (18, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 0, 3, 364500, 20000, 384500, CAST(N'2023-11-24T16:27:49.7422810' AS DateTime2), NULL)
INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (19, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 0, 3, 364500, 20000, 384500, CAST(N'2023-11-24T16:33:27.6938921' AS DateTime2), NULL)
INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (20, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 4, 3, 364500, 20000, 384500, CAST(N'2023-11-24T17:02:24.9994117' AS DateTime2), NULL)
INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (21, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 1, 3, 364500, 20000, 384500, CAST(N'2023-11-24T17:03:13.9447033' AS DateTime2), NULL)
INSERT [dbo].[Orders] ([id], [user_id], [name], [email], [phone], [address], [province], [status], [payment_method], [total_order], [delivery_fee], [total_price], [order_date], [delivery_date]) VALUES (22, 2, N'Lương Nguyễn Thành Nhân', N'20520667@gm.uit.edu.vn', N'0768631426', N'79/8G, quốc lộ 13, phường 26, quận Bình Thạnh', 30, 2, 3, 364500, 20000, 384500, CAST(N'2023-11-24T18:23:29.4692329' AS DateTime2), CAST(N'2023-11-24T18:25:35.8292117' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (1, N'BLACK JACK 01', N'black-jack-01', N'https://www.nxbtre.com.vn/Images/Book/nxbtre_full_12482021_054827.jpg', N'Osamu Tezuka', N'osamu-tezuka', N'Câu chuyện xoay quanh việc chữa bệnh cứu người và những vấn đề y khoa, trong đó nhân vật chính là Black Jack, một bác sĩ tài giỏi nhưng “quái dị”. Điểm đặc biệt của anh chính là một vết sẹo dài trên khuôn mặt mà bất cứ ai trông thấy cũng phải khiếp sợ. Những người bệnh tìm đến anh đa số là những người, hoặc người thân họ, mắc những căn bệnh lạ hay bệnh hiểm nghèo mà không có vị bác sĩ nào có thể chữa được. Họ tìm đến anh với hy vọng anh dùng tài phẫu thuật kỳ diệu của mình để giữ lại mạng sống cho họ. Mỗi tập truyện là những câu chuyện xoay quanh việc chữa trị bệnh có một không hai của bác sĩ quái dị Black Jack. Qua đó, bạn đọc được chứng kiến công việc cực nhọc, những cuộc phẫu thuật đẫm mồ hôi và cả những lúc đứng trước quyết định sinh tử của một bác sĩ. Chính nhờ đó, câu chuyện của bác sĩ Black Jack đã truyền cảm hứng cho nhiều bạn đọc truyền tranh trong việc theo đuổi đam mê nghề y của mình.\r\nBộ truyện phù hợp với lứa tuổi cấp 2 trở lên; đặc biệt cho những ai đã từng yêu Bác sĩ quái dị của những năm 90 có cơ hội đọc lại và sưu tầm bản bìa cứng.', 30000, 27000, 10, 10000, 2021, N'11.3x17.6 cm', N'Black jack', N'black-jack', 1, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (2, N'BLACK JACK 02', N'black-jack-02', N'https://www.nxbtre.com.vn/Images/Book/nxbtre_full_20402021_034001.jpg', N'Osamu Tezuka', N'osamu-tezuka', N'Câu chuyện xoay quanh việc chữa bệnh cứu người và những vấn đề y khoa, trong đó nhân vật chính là Black Jack, một bác sĩ tài giỏi nhưng “quái dị”. Điểm đặc biệt của anh chính là một vết sẹo dài trên khuôn mặt mà bất cứ ai trông thấy cũng phải khiếp sợ. Những người bệnh tìm đến anh đa số là những người, hoặc người thân họ, mắc những căn bệnh lạ hay bệnh hiểm nghèo mà không có vị bác sĩ nào có thể chữa được. Họ tìm đến anh với hy vọng anh dùng tài phẫu thuật kỳ diệu của mình để giữ lại mạng sống cho họ. Mỗi tập truyện là những câu chuyện xoay quanh việc chữa trị bệnh có một không hai của bác sĩ quái dị Black Jack. Qua đó, bạn đọc được chứng kiến công việc cực nhọc, những cuộc phẫu thuật đẫm mồ hôi và cả những lúc đứng trước quyết định sinh tử của một bác sĩ. Chính nhờ đó, câu chuyện của bác sĩ Black Jack đã truyền cảm hứng cho nhiều bạn đọc truyền tranh trong việc theo đuổi đam mê nghề y của mình.', 30000, 27000, 10, 10000, 2021, N'11.3x17.6 cm', N'Black jack', N'black-jack', 12, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (3, N'KAGUYA - CUỘC CHIẾN TỎ TÌNH - TẬP 1', N'kaguya-cuoc-chien-to-tinh-tap-1', N'https://product.hstatic.net/200000343865/product/1_24b40a928914441d9c458639392603b4_master.jpg', N'Aka Akasaka', N'aka-akasaka', N'Gia thế hiển hách, nhân cách miễn bàn! Học viện Shuchiin là nơi hội tụ những anh tài tương lai xán lạn!!\r\nVà hội học sinh của ngôi trường danh giá ấy là nơi hội trưởng Shirogane Miyuki và hội phó Shinomiya Kaguya gặp gỡ...\r\nTuy trong lòng thích nhau lắm rồi, nhưng họ đều án binh bất động, và cứ thế, nửa năm đã trôi qua!!\r\nLòng tự trọng cao ngút trời khiến cả hai không thể thành thật với nhau, trong đầu chỉ bày mưu tính kế làm thế nào để bắt người kia phải tỏ tình.\r\nTình yêu trước khi đơm hoa kết trái thường ngập tràn tiếng cười. Câu chuyện hài hước đời thường về “cuộc chiến cân não” đầy mới mẻ đã bắt đầu!!', 40000, 36000, 10, 12000, 2022, N'13x18 cm', N'Kaguya - Cu?c chi?n t? tình', N'kaguya-cuoc-chien-to-tinh', 3, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (4, N'KAGUYA - CUỘC CHIẾN TỎ TÌNH - TẬP 2', N'kaguya-cuoc-chien-to-tinh-tap-2', N'https://product.hstatic.net/200000343865/product/2_d3442b14540742fcbba347f3e5ff30fb_master.jpg', N'Aka Akasaka', N'aka-akasaka', N'Gia thế hiển hách, nhân cách miễn bàn! Học viện Shuchiin là nơi hội tụ những anh tài tương lai xán lạn!!\r\nVà Hội Học Sinh của ngôi trường danh giá ấy là nơi hội trưởng Shirogane Miyuki và hội phó Shinomiya Kaguya gặp nhau...\r\nĐây là câu chuyện tình cảm hài hước mới mẻ về hai thiên tài tuy trong lòng thích nhau lắm rồi, nhưng vẫn ngày ngày bày mưu tính kế cò cưa, bắt đối phương phải tỏ tình trước!!!\r\nTrong tập 2, cuộc chiến tỏ tình giữa hai thiên tài vẫn tiếp tục qua màn trao đổi địa chỉ liên lạc, nụ hôn gián tiếp, kinh nghiệm lần đầu, tin nhắn đầu tiên, cosplay... Mời các bạn đón đọc!', 40000, 36000, 10, 12000, 2022, N'13x18 cm', N'Kaguya - Cu?c chi?n t? tình', N'kaguya-cuoc-chien-to-tinh', 3, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (5, N'KAGUYA - CUỘC CHIẾN TỎ TÌNH - TẬP 3', N'kaguya-cuoc-chien-to-tinh-tap-3', N'https://product.hstatic.net/200000343865/product/3_79fefff7d3c64c5e87ff6f1dc9eb3cf6_master.jpg', N'Aka Akasaka', N'aka-akasaka', N'Gia thế hiển hách, nhân cách miễn bàn! Học viện Shuchiin là nơi hội tụ những anh tài tương lai xán lạn!!\r\nHội trưởng Shirogane Miyuki và hội phó Shinomiya Kaguya gặp nhau tại Hội Học Sinh của học viện Shuchiin, nơi hội tụ của những con người thuộc tầng lớp thượng lưu...\r\nĐây là câu chuyện tình cảm hài hước mới mẻ về hai thiên tài tuy trong lòng thích nhau lắm rồi, nhưng vẫn ngày ngày bày mưu tính kế cò cưa, bắt đối phương phải tỏ tình trước.\r\nTập 3 với sự xuất hiện của một nhân vật mới, thủ quỹ của Hội Học Sinh!!\r\nNgoài ra mời các bạn theo dõi những mẩu truyện thú vị như: che chung ô, truyện tranh thiếu nữ,\r\nbóng chuyền, làm móng, tiếng lóng, sinh hoạt câu lạc bộ, kiểm tra cuối kì..\r\n\r\n“Người thông minh chỉ cần 10 năm để ngộ ra chân lí, còn kẻ khờ lại mất đến cả trăm năm. Người thông minh mất trăm năm để hiểu ái tình, kẻ khờ lại tức khắc tường tận.”\r\n\r\nSách Tặng kèm 1 trong 2 mẫu thẻ học sinh cho bản in đầu tiên', 40000, 36000, 10, 12000, 2022, N'13x18 cm', N'Kaguya - Cu?c chi?n t? tình', N'kaguya-cuoc-chien-to-tinh', 3, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (6, N'THANH GƯƠM DIỆT QUỶ - TẬP 1', N'thanh-guom-diet-quy-tap-1', N'https://product.hstatic.net/200000343865/product/1_c75fb8f63dd542c6896796e00a0f170f_master.jpg', N'Koyoharu Gotouge', N'koyoharu-gotouge', N'Vào thời Taisho, có một cậu bé bán than với tấm lòng nhân hậu tên Tanjiro. Những ngày yên bình đã chẳng còn khi Quỷ đến tàn sát cả gia đình cậu, chỉ duy nhất người em gái Nezuko còn sống sót nhưng lại bị biến thành Quỷ. Mang trong mình quyết tâm chữa cho em gái, Tanjiro đã cùng Nezuko bắt đầu cuộc hành trình tìm kiếm tung tích con quỷ đã ra tay với gia đình cậu!!\r\n\r\nCuộc phiêu lưu trên con đường kiếm sĩ đã bắt đầu!!', 25000, 22500, 10, 10000, 2022, N'11.3x17.6 cm', N'Thanh guom di?t qu?', N'thanh-guom-diet-quy', 13, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (7, N'THANH GƯƠM DIỆT QUỶ - TẬP 2', N'thanh-guom-diet-quy-tap-2', N'https://product.hstatic.net/200000343865/product/2_f863d41a01704527bd8d68c978f349fa_master.jpg', N'Koyoharu Gotouge', N'koyoharu-gotouge', N'Trong bài tuyển chọn cuối cùng để vào đội Diệt quỷ, Tanjiro đã dùng những chiêu học được từ thầy Urokodaki để đối đầu với một con quỷ đột biến!!\r\n\r\nCuối cùng cậu có vượt qua cuộc tuyển chọn không!? Và khi cậu trở về với Urokodaki, Nezuko đã tỉnh dậy!! Tanjiro cùng em gái hướng đến một con phố, nơi đang xảy ra hàng loạt những vụ án các cô gái bị mất tích mỗi đêm...!', 25000, 22500, 10, 10000, 2021, N'11.3x17.6 cm', N'Thanh guom di?t qu?', N'thanh-guom-diet-quy', 13, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (8, N'THANH GƯƠM DIỆT QUỶ - TẬP 3', N'thanh-guom-diet-quy-tap-3', N'https://product.hstatic.net/200000343865/product/3_b171a14781b041949b03f3458eb5a67e_master.jpg', N'Koyoharu Gotouge', N'koyoharu-gotouge', N'Tanjiro và Nezuko phải đối đầu với 2 con quỷ sử dụng quả cầu vải và mũi tên. Chúng là thuộc cấp của Kibutsuji. Với sự giúp đỡ của Tamayo và Yushiro, Tanjiro đã chiến đấu lại với những con quỷ mang tên Nhị Thập Quỷ Nguyệt!! Sau khi giành chiến thắng, liệu cậu có lần ra được tung tích của Kibutsuji!?', 25000, 22500, 10, 10000, 2021, N'11.3x17.6 cm', N'Thanh guom di?t qu?', N'thanh-guom-diet-quy', 13, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (9, N'BLACK JACK 03', N'black-jack-03', N'https://www.nxbtre.com.vn/Images/Book/nxbtre_full_18072021_100719.jpg', N'Osamu Tezuka', N'osamu-tezuka', N'Câu chuyện xoay quanh việc chữa bệnh cứu người và những vấn đề y khoa, trong đó nhân vật chính là Black Jack, một bác sĩ tài giỏi nhưng “quái dị”. Điểm đặc biệt của anh chính là một vết sẹo dài trên khuôn mặt mà bất cứ ai trông thấy cũng phải khiếp sợ. Những người bệnh tìm đến anh đa số là những người, hoặc người thân họ, mắc những căn bệnh lạ hay bệnh hiểm nghèo mà không có vị bác sĩ nào có thể chữa được. Họ tìm đến anh với hy vọng anh dùng tài phẫu thuật kỳ diệu của mình để giữ lại mạng sống cho họ. Mỗi tập truyện là những câu chuyện xoay quanh việc chữa trị bệnh có một không hai của bác sĩ quái dị Black Jack. Qua đó, bạn đọc được chứng kiến công việc cực nhọc, những cuộc phẫu thuật đẫm mồ hôi và cả những lúc đứng trước quyết định sinh tử của một bác sĩ. Chính nhờ đó, câu chuyện của bác sĩ Black Jack đã truyền cảm hứng cho nhiều bạn đọc truyền tranh trong việc theo đuổi đam mê nghề y của mình.\r\nBộ truyện phù hợp với lứa tuổi cấp 2 trở lên; đặc biệt cho những ai đã từng yêu Bác sĩ quái dị của những năm 90 có cơ hội đọc lại và sưu tầm bản bìa cứng.', 30000, 27000, 10, 10000, 2021, N'11.3x17.6 cm', N'Black jack', N'black-jack', 12, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (10, N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 1', N're-zero-bat-dau-lai-o-the-gioi-khac-1', N'https://product.hstatic.net/200000287623/product/re_-_1__ln__6e45b602933c485db21f1359bfe42a56_master.jpg', N'Tappei Nagatsuki', N'tappei-nagatsuki', N'Một thiếu niên bước ra khỏi cửa hàng tiện lợi, và chớp mắt một cái đã thấy mình xuất hiện trước sạp trái cây ở một khu vực kì lạ, nơi mái tóc đen và bộ đồ thể thao xám bình thường tột độ của cậu trở nên bất thường. Vì bao quanh cậu là đầu tóc sặc sỡ, ăn vận kì dị và các sinh vật với đủ mọi biến thể gene. Dĩ nhiên đó là do, cậu vừa bị triệu hồi tới thế giới khác.Với trí tưởng tượng được nuôi nấng no nê nhờ các sản phẩm giải trí viễn tưởng ảo tưởng giả tưởng hoang tưởng, thiếu niên mau chóng nhận ra cảnh ngộ gặp phải và mò mẫm thử nghiệm xem mình được trao tặng siêu năng lực gì ở đây.', 120000, 108000, 10, 8000, 2021, N'13x18 cm', N'Re: Zero', N're-zero', 11, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (12, N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 2', N're-zero-bat-dau-lai-o-the-gioi-khac-2', N'https://product.hstatic.net/200000287623/product/re_-_2__ln__969c5b78ca564d7489fbe2393ac32f5a_master.jpg', N'Tappei Nagatsuki', N'tappei-nagatsuki', N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 2 - Hành trình ở thế giới khác, một lần nữa, bắt đầu. \r\n\r\nThoát khỏi vòng lặp chết chóc ở vương đô, Subaru tỉnh dậy trong một biệt thự sang trọng, bên cạnh là hai nàng hầu gái song sinh.\r\n\r\nHai nàng hầu quyến rũ, một cô nhóc loli làm thủ thư khó tính, một tiên nữ xinh đẹp tuyệt trần, một con mèo tinh linh nghịch ngợm, và một bá tước… có vẻ biến thái. Cậu cứ ngỡ từ giờ cuộc sống sẽ được bình yên bên những người này, cho đến khi cậu lại một lần nữa rơi vào vòng lặp chết chóc.', 120000, 108000, 10, 8000, 2021, N'13x18 cm', N'Re: Zero', N're-zero', 11, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (13, N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 3', N're-zero-bat-dau-lai-o-the-gioi-khac-3', N'https://product.hstatic.net/200000287623/product/re_-_3__ln__f429a7c2dd3e4e719df8770b4b32385a_master.jpg', N'Tappei Nagatsuki', N'tappei-nagatsuki', N'Giới thiệu sách: Re:zero - Bắt Đầu Lại Ở Thế Giới Khác 3 … Nào thì khởi động câu chuyện mới. Để cùng đón ánh ban mai, với những người chúng ta trân trọng. Subaru hạ quyết tâm quay lại với dinh thự Roswaal.', 95000, 85500, 10, 8000, 2018, N'13x18 cm', N'Re: Zero', N're-zero', 11, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (14, N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 4', N're-zero-bat-dau-lai-o-the-gioi-khac-4', N'https://product.hstatic.net/200000287623/product/re_-_4__ln__d726528eb19048bbb53b518a6921b7c2_master.jpg', N'Tappei Nagatsuki', N'tappei-nagatsuki', N'Giới thiệu sách: Re:zero - Bắt Đầu Lại Ở Thế Giới Khác 4 - Tặng Kèm 1 Bookmark PVC In Màu + 1 Bọc Sách Plastic (Số Lượng Có Hạn) Sau khi thoát khỏi vòng lặp tử vong tại dinh thự, Subaru trở lại với tháng ngày bình yên.', 95000, 85500, 10, 8000, 2019, N'13x18 cm', N'Re: Zero', N're-zero', 11, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (15, N'Re: Zero - Bắt Đầu Lại Ở Thế Giới Khác - 5', N're-zero-bat-dau-lai-o-the-gioi-khac-5', N'https://product.hstatic.net/200000287623/product/re_-_5__ln__8c72391a0c1a4f3988dec956af0893a7_master.jpg', N'Tappei Nagatsuki', N'tappei-nagatsuki', N'Giới thiệu sách: Re:zero - Bắt Đầu Lại Ở Thế Giới Khác 5 - Tặng Kèm 1 Bookmark PVC In Màu + 1 Bọc Sách Plastic (Số Lượng Có Hạn) “Đủ rồi… Natsuki Subaru.” Đã ba ngày trôi qua kể từ cuộc chia ly nghiệt ngã với Emilia', 95000, 85500, 10, 8000, 2019, N'13x18 cm', N'Re: Zero', N're-zero', 11, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (16, N'LỚP HỌC RÙNG RỢN - TẬP 1', N'lop-hoc-rung-ron-tap-1', N'https://product.hstatic.net/200000343865/product/1_6ff6e1a850074fc999360a5e2985d235_master.jpg', N'Emi Ishikawa', N'emi-ishikawa', N'“Trong cuộc sống hằng ngày tẻ nhạt còn ẩn chứa một thế giới khác. Giờ, tôi sẽ đưa bạn đến đó…\r\nChào mừng đến với lớp học rùng rợn.”\r\n\r\nCùng với sự dẫn dắt của hồn ma Yumi, độc giả sẽ được "tham dự" những tiết học lạnh sống lưng, với những trải nghiệm chưa từng được biết đến. Nhân vật chính trong mỗi tiết học là bất cứ học sinh nào chúng ta có thể gặp ở trường. Có thể là một cô bé muốn đổi mẹ ruột với một người mẹ trên mạng, để rồi phải trả giá đắt; một học sinh nổi bật trong lớp vì muốn được làm tâm điểm mà gây ra tội lỗi tày trời; hay cô bé mãi mãi bị giam cầm trong giấc mơ, chơi trò đuổi bắt vô tận… \r\nSau mỗi tiết học sẽ là những chiêm nghiệm về cuộc sống, để mỗi người chúng ta tự soi chiếu chính mình. \r\n\r\nMùa thu này, xin mời các độc giả cùng đến với "LỚP HỌC RÙNG RỢN", Series Manga rất được yêu thích của nữ tác giả Emi Ishikawa, từng đạt giải thưởng Shogakukan Manga lần thứ 59 nhé.', 30000, 27000, 10, 5000, 2022, N'11.3x17.6 cm', N'L?p h?c rùng r?n', N'lop-hoc-rung-ron', 2, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (17, N'LỚP HỌC RÙNG RỢN - TẬP 2', N'lop-hoc-rung-ron-tap-2', N'https://product.hstatic.net/200000343865/product/2_8c91ed3921924c58988385eea9ebe41a_master.jpg', N'Emi Ishikawa', N'emi-ishikawa', N'Chào mừng đến với lớp học rùng rợn! Không cần mang sách giáo khoa hay tập vở đâu.\r\nNếu bạn đã chuẩn bị tinh thần... Tới đây mở cửa ra xem nào!\r\n\r\nEMI ISHIKAWA\r\n“Lớp học rùng rợn” đã phát hành tập 2 rồi nè! Cho dù đang vui vẻ đi ăn uống hay shopping cùng bạn bè thì lúc nào trong đầu tôi cũng chỉ toàn những mẩu truyện kinh dị… Rùng hết cả mình!! (Ha ha)', 30000, 27000, 10, 5000, 2022, N'11.3x17.6 cm', N'L?p h?c rùng r?n', N'lop-hoc-rung-ron', 2, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (18, N'Overlord - 1', N'overlord-1', N'https://product.hstatic.net/200000287623/product/overlord_1__ln__a45a2c379bfe4eb9b2b736596088f5fd_master.jpg', N'Maruyama Kugane', N'maruyama-kugane', N'Giới thiệu sách: Chuyện xảy ra vào năm 2138, thời đại công nghệ thực tế ảo phát triển đến đỉnh cao, giúp người chơi game trải nghiệm thế giới ảo theo một cách chân thực nhất. Trong số game ấy có một trò đỉnh cao. Trong trò ấy có một guild đỉnh cao. Trong guild ấy có một thủ lĩnh gắn bó đỉnh cao.', 135000, 121500, 10, 10000, 2020, N'13x18 cm', N'Overlord', N'overlord', 5, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (19, N'Overlord - 2', N'overlord-2', N'https://product.hstatic.net/200000287623/product/overlord_2__ln__51a546428a034d4c9048584188b920df_master.jpg', N'Maruyama Kugane', N'maruyama-kugane', N'Giới thiệu sách: Vào ngày hoạt động cuối cùng của game YGGDRASIL, do hiện tượng bí ẩn nào đó, một người chơi là Momonga trong tạo hình nhân vật bộ xương tự nhiên bị dịch chuyển tới một thế giới xa lạ. Đã tám ngày trôi qua.', 135000, 121500, 10, 10000, 2020, N'13x18 cm', N'Overlord', N'overlord', 5, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (20, N'Overlord - 3', N'overlord-3', N'https://product.hstatic.net/200000287623/product/overlord_3__ln__e4931f1f4a294f158e8ddeb7179cd468_master.jpg', N'Maruyama Kugane', N'maruyama-kugane', N'Giới thiệu sách: OVERLORD - Tập 3: Valkyrie Khát Máu Mở đầu cho một hành trình huy hoàng, thông thường sẽ có hai phong cách. Một, nhân vật chính là người bình thường, không biết gì cả, lơ ngơ đơn thuần rơi vào một thế giới xa lạ, đi đâu cũng đụng kẻ mạnh và va vấp với muôn vàn thử thách', 135000, 121500, 10, 10000, 2020, N'13x18 cm', N'Overlord', N'overlord', 5, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (21, N'Overlord - 4', N'overlord-4', N'https://product.hstatic.net/200000287623/product/overlord_4__ln__f8aad5451ddb4f1484fb16d68c8c4b98_master.jpg', N'Maruyama Kugane', N'maruyama-kugane', N'Overlord kể về Suzuki Satoru, hay Ainz, một nhân viên văn phòng say mê tâm huyết với game ruột YGGDRASIL đến mức đồng đội gắn bó một thời đã lần lượt rời xa, chính cái game cũng sắp dừng hoạt động, anh vẫn đăng nhập để nhâm nhi hoài niệm và đi cùng nó những phút giây sau cuối.', 135000, 121500, 10, 10000, 2021, N'13x18 cm', N'Overlord', N'overlord', 5, N'')
INSERT [dbo].[Products] ([id], [name], [slug], [image], [author], [author_slug], [description], [list_price], [price], [discount_rate], [quantity], [publish_year], [size], [collection], [collection_slug], [category], [image_uuid]) VALUES (22, N'Overlord - 5', N'overlord-5', N'https://product.hstatic.net/200000287623/product/overlord_5__ln__-_bia1_a3473e6167824ae4b0203ed64cbe52e1_master.jpg', N'Maruyama Kugane', N'maruyama-kugane', N'Suzuki Satoru, hay Ainz, một nhân viên văn phòng say mê YGGDRASIL vẫn đăng nhập để nhâm nhi những giây phút sau cuối trước khi game dừng hoạt động. Nhưng khi đã sẵn sàng tinh thần chia tay các NPC dù vô tri vô giác nhưng là những đứa con tinh thần của mình, anh lại không chủ động đăng xuất được nữa mà nhảy vọt sang dị thế giới.', 135000, 121500, 10, 9991, 2021, N'13x18 cm', N'Overlord', N'overlord', 5, N'')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [account_id], [name], [gender], [phone], [address], [province]) VALUES (2, 2, N'Lương Nguyễn Thành Nhân', 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Accounts_email]    Script Date: 19/12/2023 22:23:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Accounts_email] ON [dbo].[Accounts]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartDetails_product_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE NONCLUSTERED INDEX [IX_CartDetails_product_id] ON [dbo].[CartDetails]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_user_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Carts_user_id] ON [dbo].[Carts]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_product_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_product_id] ON [dbo].[OrderDetails]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_user_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_user_id] ON [dbo].[Orders]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_name]    Script Date: 19/12/2023 22:23:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_name] ON [dbo].[Products]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Products_slug]    Script Date: 19/12/2023 22:23:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_slug] ON [dbo].[Products]
(
	[slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sample_product_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE NONCLUSTERED INDEX [IX_Sample_product_id] ON [dbo].[Sample]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_account_id]    Script Date: 19/12/2023 22:23:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_account_id] ON [dbo].[Users]
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [image_uuid]
GO
ALTER TABLE [dbo].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Carts_cart_id] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Carts] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Carts_cart_id]
GO
ALTER TABLE [dbo].[CartDetails]  WITH CHECK ADD  CONSTRAINT [FK_CartDetails_Products_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetails] CHECK CONSTRAINT [FK_CartDetails_Products_product_id]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users_user_id]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_order_id] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_order_id]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_product_id]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_user_id] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_user_id]
GO
ALTER TABLE [dbo].[Sample]  WITH CHECK ADD  CONSTRAINT [FK_Sample_Products_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sample] CHECK CONSTRAINT [FK_Sample_Products_product_id]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Accounts_account_id] FOREIGN KEY([account_id])
REFERENCES [dbo].[Accounts] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Accounts_account_id]
GO
USE [master]
GO
ALTER DATABASE [mangastore] SET  READ_WRITE 
GO
