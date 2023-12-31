USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 05.06.2023 18:39:34 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Users\Hyperpop\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Users\Hyperpop\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = OFF
GO
USE [BookStore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
-- создать на локальном сервере (LocalDB)\MSSQLLocalDB и запустить с этого момента для создания и заполнения бд
USE [BookStore]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorSurname] [nvarchar](50) NOT NULL,
	[AuthorName] [nvarchar](50) NOT NULL,
	[AuthorPatronymic] [nvarchar](50) NULL,
	[AuthorDateOfBirth] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](max) NOT NULL,
	[BookDescription] [nvarchar](max) NULL,
	[BookGenreID] [int] NOT NULL,
	[ProviderID] [int] NOT NULL,
	[PublishingHouseID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[BookISBN] [nvarchar](13) NULL,
	[BookCount] [int] NOT NULL,
	[BookPrice] [int] NOT NULL,
	[BookImage] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookGenre]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookGenre](
	[BookGenreID] [int] IDENTITY(1,1) NOT NULL,
	[BookGenreName] [nvarchar](100) NOT NULL,
	[BookGenreDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookGenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientLogin] [nvarchar](max) NOT NULL,
	[ClientPassword] [nvarchar](max) NOT NULL,
	[ClientSurname] [nvarchar](50) NOT NULL,
	[ClientName] [nvarchar](50) NOT NULL,
	[ClientPatronymic] [nvarchar](50) NULL,
	[ClientAddress] [nvarchar](max) NULL,
	[ClientPhoneNumber] [nvarchar](11) NULL,
	[RoleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[OrderCount] [int] NOT NULL,
	[OrderCreateDate] [date] NOT NULL,
	[OrderDeliveryDate] [date] NOT NULL,
	[OrderStatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusID] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatusName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](100) NOT NULL,
	[ProviderAddress] [nvarchar](500) NOT NULL,
	[ProviderPhoneNumber] [nvarchar](11) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublishingHouse]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishingHouse](
	[PublishingHouseID] [int] IDENTITY(1,1) NOT NULL,
	[PublishingHouseName] [nvarchar](100) NOT NULL,
	[PublishingDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PublishingHouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05.06.2023 18:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (1, N'Пушкин', N'Александр', N'Сергеевич', CAST(N'1799-06-06' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (2, N'Толстой', N'Лев', N'Николаевич', CAST(N'1828-09-09' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (3, N'Достоевский', N'Федор', N'Михайлович', CAST(N'1821-11-11' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (4, N'Тургенев', N'Иван', N'Сергеевич', CAST(N'1818-11-09' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (5, N'Чехов', N'Антон', N'Павлович', CAST(N'1860-01-29' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (6, N'Гоголь', N'Николай', N'Васильевич', CAST(N'1809-03-31' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (7, N'Булгаков', N'Михаил', N'Афанасьевич', CAST(N'1891-05-15' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (8, N'Паустовский', N'Константин', N'Георгиевич', CAST(N'1892-05-31' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (9, N'Шолохов', N'Михаил', N'Александрович', CAST(N'1905-05-24' AS Date))
INSERT [dbo].[Author] ([AuthorID], [AuthorSurname], [AuthorName], [AuthorPatronymic], [AuthorDateOfBirth]) VALUES (10, N'Солженицын', N'Александр', N'Исаевич', CAST(N'1918-12-11' AS Date))
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (3, N'Евгений Онегин', N'Роман в стихах', 2, 1, 1, 1, N'9785699880168', 10, 200, N'image1.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (4, N'Война и мир', N'Роман-эпопея', 2, 2, 2, 2, N'9785170916469', 8, 500, N'image2.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (5, N'Преступление и наказание', N'Роман', 2, 3, 1, 3, N'9785389016622', 7, 300, N'image3.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (6, N'Отцы и дети', N'Роман', 2, 4, 2, 4, N'9785521001488', 5, 250, N'image4.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (7, N'Вишневый сад', N'Пьеса', 2, 5, 1, 5, N'9785171054114', 10, 150, N'image5.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (8, N'Мертвые души', N'Поэма', 2, 6, 2, 6, N'9785389056940', 6, 200, N'image6.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (9, N'Мастер и Маргарита', N'Роман', 2, 7, 1, 7, N'9785171183678', 8, 350, N'image7.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (10, N'Золотой теленок', N'Роман', 2, 8, 2, 8, N'9785389060306', 9, 300, N'image8.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (11, N'Тихий Дон', N'Эпический роман', 2, 9, 1, 9, N'9785224022011', 4, 600, N'image9.jpg')
INSERT [dbo].[Book] ([BookID], [BookName], [BookDescription], [BookGenreID], [ProviderID], [PublishingHouseID], [AuthorID], [BookISBN], [BookCount], [BookPrice], [BookImage]) VALUES (12, N'Архипелаг ГУЛАГ', N'Эпопея', 1, 10, 2, 10, N'9785170889125', 7, 700, N'image10.jpg')
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[BookGenre] ON 

INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (1, N'Эпопея', N'Эпические произведения, рассказывающие о великих событиях и героях')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (2, N'Роман', N'Произведения, рассказывающие о событиях и отношениях героев')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (3, N'Пьеса', N'Театральные произведения, предназначенные для постановки на сцене')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (4, N'Поэма', N'Большое поэтическое произведение, обычно рассказывающее о высоких чувствах и идеалах')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (5, N'Фантастика', N'Произведения, основанные на научных и фантастических предположениях')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (6, N'Детектив', N'Произведения, где главным сюжетным элементом является раскрытие преступления')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (7, N'Исторический роман', N'Произведения, основанные на реальных исторических событиях и персонажах')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (8, N'Фэнтези', N'Произведения, основанные на мифологических и волшебных элементах')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (9, N'Научная литература', N'Произведения, посвященные научным открытиям и исследованиям')
INSERT [dbo].[BookGenre] ([BookGenreID], [BookGenreName], [BookGenreDescription]) VALUES (10, N'Поэзия', N'Литературный жанр, основанный на использовании стихотворных форм и языковых особенностей')
SET IDENTITY_INSERT [dbo].[BookGenre] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (1, N'ivanov', N'password1', N'Иванов', N'Иван', N'Иванович', N'Москва, ул. Садовая, 3', N'79211234567', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (2, N'petrov', N'password2', N'Петров', N'Петр', N'Петрович', N'Санкт-Петербург, пр. Ленина, 5', N'79222345678', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (3, N'sidorov', N'password3', N'Сидоров', N'Сидор', N'Сидорович', N'Казань, ул. Кремлевская, 7', N'79233456789', 2)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (4, N'bulatov', N'password4', N'Булатов', N'Глеб', N'Станиславович', N'Ростов-на-Дону, пр. Мира, 9', N'79244567890', 1)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (5, N'alexeev', N'password5', N'Алексеев', N'Алексей', N'Алексеевич', N'Самара, ул. Самарская, 11', N'79255678901', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (6, N'andreev', N'password6', N'Андреев', N'Андрей', N'Андреевич', N'Екатеринбург, пр. Ленина, 13', N'79266789012', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (7, N'vasiliev', N'password7', N'Васильев', N'Василий', N'Васильевич', N'Новосибирск, ул. Сибирская, 15', N'79277890123', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (8, N'sergeev', N'password8', N'Сергеев', N'Сергей', N'Сергеевич', N'Владивосток, пр. Морской, 17', N'79288901234', 2)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (9, N'mikhailov', N'password9', N'Михайлов', N'Михаил', N'Михайлович', N'Мурманск, ул. Северная, 19', N'79299012345', 3)
INSERT [dbo].[Client] ([ClientID], [ClientLogin], [ClientPassword], [ClientSurname], [ClientName], [ClientPatronymic], [ClientAddress], [ClientPhoneNumber], [RoleID]) VALUES (10, N'nikitin', N'password10', N'Никитин', N'Никита', N'Никитич', N'Ульяновск, ул. Ульяновская, 21', N'79300123456', 3)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (7, 1, 3, 2, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-07' AS Date), 1)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (8, 2, 4, 1, CAST(N'2023-06-02' AS Date), CAST(N'2023-06-08' AS Date), 2)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (9, 3, 5, 3, CAST(N'2023-06-03' AS Date), CAST(N'2023-06-09' AS Date), 3)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (10, 4, 6, 2, CAST(N'2023-06-04' AS Date), CAST(N'2023-06-10' AS Date), 4)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (11, 5, 7, 1, CAST(N'2023-06-05' AS Date), CAST(N'2023-06-11' AS Date), 5)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (12, 6, 8, 4, CAST(N'2023-06-06' AS Date), CAST(N'2023-06-12' AS Date), 6)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (13, 7, 9, 1, CAST(N'2023-06-07' AS Date), CAST(N'2023-06-13' AS Date), 7)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (14, 8, 10, 2, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-14' AS Date), 8)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (15, 9, 11, 1, CAST(N'2023-06-09' AS Date), CAST(N'2023-06-15' AS Date), 9)
INSERT [dbo].[Order] ([OrderID], [ClientID], [BookID], [OrderCount], [OrderCreateDate], [OrderDeliveryDate], [OrderStatusID]) VALUES (16, 10, 12, 3, CAST(N'2023-06-10' AS Date), CAST(N'2023-06-16' AS Date), 10)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (1, N'Новый')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (2, N'Принят в обработку')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (3, N'Оплачен')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (4, N'Отправлен')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (5, N'Доставлен')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (6, N'Отменен')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (7, N'Возвращен')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (8, N'Ожидает оплаты')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (9, N'Ожидает возврата')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (10, N'Завершен')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (1, N'ООО "Русская книга"', N'Москва, ул. Тверская, 3', N'79211231234')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (2, N'ЗАО "ЛитРес"', N'Санкт-Петербург, пр. Невский, 5', N'79222342345')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (3, N'ООО "Азбука-Аттикус"', N'Москва, ул. Садовая, 7', N'79233453456')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (4, N'ООО "Питер"', N'Санкт-Петербург, пр. Васильевский, 9', N'79244564567')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (5, N'ООО "Эксмо"', N'Москва, ул. Пушкинская, 11', N'79255675678')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (6, N'ООО "АСТ"', N'Москва, ул. Кутузовская, 13', N'79266786789')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (7, N'ООО "Московский Книжный Дом"', N'Москва, ул. Таганская, 15', N'79277897890')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (8, N'ООО "Дрофа"', N'Москва, ул. Ленинская, 17', N'79288908901')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (9, N'ООО "Росмэн"', N'Москва, ул. Красная, 19', N'79299019012')
INSERT [dbo].[Provider] ([ProviderID], [ProviderName], [ProviderAddress], [ProviderPhoneNumber]) VALUES (10, N'ООО "Альфа-книга"', N'Москва, ул. Белая, 21', N'79300120123')
SET IDENTITY_INSERT [dbo].[Provider] OFF
GO
SET IDENTITY_INSERT [dbo].[PublishingHouse] ON 

INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (1, N'Эксмо', N'Одно из крупнейших издательств в России')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (2, N'АСТ', N'Издательство, включающее в себя более 20 брендов')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (3, N'Росмэн', N'Издательство детской и подростковой литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (4, N'Махаон', N'Издательство детской литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (5, N'Питер', N'Издательство профессиональной и бизнес-литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (6, N'Альфа-книга', N'Издательство популярной литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (7, N'Азбука-Аттикус', N'Издательство, включающее в себя более 10 брендов')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (8, N'Манн, Иванов и Фербер', N'Издательство нехудожественной литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (9, N'Э', N'Издательство художественной литературы')
INSERT [dbo].[PublishingHouse] ([PublishingHouseID], [PublishingHouseName], [PublishingDescription]) VALUES (10, N'Просвещение', N'Крупнейшее издательство учебной литературы')
SET IDENTITY_INSERT [dbo].[PublishingHouse] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Пользователь')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([BookGenreID])
REFERENCES [dbo].[BookGenre] ([BookGenreID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([ProviderID])
REFERENCES [dbo].[Provider] ([ProviderID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([PublishingHouseID])
REFERENCES [dbo].[PublishingHouse] ([PublishingHouseID])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([OrderStatusID])
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
