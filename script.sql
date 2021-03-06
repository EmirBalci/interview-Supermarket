USE [master]
GO
/****** Object:  Database [SuperMarket]    Script Date: 28.10.2021 01:04:56 ******/
CREATE DATABASE [SuperMarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SuperMarket', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SuperMarket.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SuperMarket_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SuperMarket_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SuperMarket] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SuperMarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SuperMarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SuperMarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SuperMarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SuperMarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SuperMarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [SuperMarket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SuperMarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SuperMarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SuperMarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SuperMarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SuperMarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SuperMarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SuperMarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SuperMarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SuperMarket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SuperMarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SuperMarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SuperMarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SuperMarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SuperMarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SuperMarket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SuperMarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SuperMarket] SET RECOVERY FULL 
GO
ALTER DATABASE [SuperMarket] SET  MULTI_USER 
GO
ALTER DATABASE [SuperMarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SuperMarket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SuperMarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SuperMarket] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SuperMarket] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SuperMarket] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SuperMarket', N'ON'
GO
ALTER DATABASE [SuperMarket] SET QUERY_STORE = OFF
GO
USE [SuperMarket]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 28.10.2021 01:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Piece] [int] NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 28.10.2021 01:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Stock] [int] NULL,
	[Price] [money] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 28.10.2021 01:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[TotalPrice] [money] NULL,
	[PaymentType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDetail]    Script Date: 28.10.2021 01:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[SalesId] [uniqueidentifier] NULL,
	[ProductId] [uniqueidentifier] NULL,
	[Piece] [int] NULL,
 CONSTRAINT [PK_SalesDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28.10.2021 01:04:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Phone] [nchar](11) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Product] ([Id], [Name], [Type], [Stock], [Price], [IsDeleted]) VALUES (N'f22277e8-d50b-4b8e-8506-6ff6954f3289', N'Parfüm', N'Kozmetik', 226, 10.0000, 0)
INSERT [dbo].[Product] ([Id], [Name], [Type], [Stock], [Price], [IsDeleted]) VALUES (N'64fae204-8b0e-442c-81d8-c09e51bb2fb1', N'Fanta', N'Meşrubat', 978, 10.0000, 0)
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [Firstname], [Lastname], [Phone]) VALUES (N'3979b03e-8c5b-4e79-a964-5af1bd13fa32', N'admin', N'admin', N'admin', N'admin', N'01234567890')
GO
ALTER TABLE [dbo].[Basket] ADD  CONSTRAINT [DF_Basket_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sales] ADD  CONSTRAINT [DF_Sales_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Product1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Product1]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_User1]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_User]
GO
ALTER TABLE [dbo].[SalesDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SalesDetail] CHECK CONSTRAINT [FK_SalesDetail_Product]
GO
ALTER TABLE [dbo].[SalesDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesDetail_Sales] FOREIGN KEY([SalesId])
REFERENCES [dbo].[Sales] ([Id])
GO
ALTER TABLE [dbo].[SalesDetail] CHECK CONSTRAINT [FK_SalesDetail_Sales]
GO
USE [master]
GO
ALTER DATABASE [SuperMarket] SET  READ_WRITE 
GO
