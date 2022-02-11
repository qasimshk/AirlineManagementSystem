CREATE DATABASE Customers

ALTER DATABASE [Customers] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Customers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Customers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Customers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Customers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Customers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Customers] SET ARITHABORT OFF 
GO
ALTER DATABASE [Customers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Customers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Customers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Customers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Customers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Customers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Customers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Customers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Customers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Customers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Customers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Customers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Customers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Customers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Customers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Customers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Customers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Customers] SET RECOVERY FULL 
GO
ALTER DATABASE [Customers] SET  MULTI_USER 
GO
ALTER DATABASE [Customers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Customers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Customers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Customers] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Customers] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Customers] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Customers', N'ON'
GO
ALTER DATABASE [Customers] SET QUERY_STORE = OFF
GO
USE [Customers]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2022 10:11:11 AM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 10/02/2022 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerRef] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[EmailAddress] [nvarchar](30) NOT NULL,
	[CorrelationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211028165512_InitialCreate', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (10, N'eb970c72-07f9-479b-85a7-bcbff5705cc3', N'Qasim', N'Sheikh', N'qasim@abc.com', N'31a1df72-5abf-438c-a6fd-559be2d99b65')
INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (11, N'631b49ec-37a6-44b7-b207-b53b18c7b592', N'Qasim', N'Kainos', N'qkainos@abc.com', N'7c1fd37d-de63-46da-8500-786308724b07')
INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (12, N'f4cbd08d-941d-4439-9a3f-76d0fd11f54f', N'Emma', N'Reilly', N'emma@abc.com', N'c41a077c-bcb9-4362-ad45-23a169cc452d')
INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (13, N'f5ff9369-3fa2-430d-b6b1-ee396e985448', N'Tom', N'Jerry', N'tom@abc.com', N'97a9e3dd-6108-470e-bad4-b2d8a2dc2949')
INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (14, N'd1798411-6661-453e-b308-0d1ce8d4563f', N'Qasim', N'Sheikh', N'qasim@abcd.com', N'454e1e3a-feb4-42b2-9467-15d9d15fa65f')
INSERT [dbo].[Customers] ([Id], [CustomerRef], [FirstName], [LastName], [EmailAddress], [CorrelationId]) VALUES (15, N'475f0920-af6a-4eee-9c11-b73c6d7105dc', N'Qasim', N'Sheikh', N'demo@example.com', N'5933c2c0-95b4-4b54-81b3-0ff6a18ee514')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
/****** Object:  Index [IX_Customers_CorrelationId]    Script Date: 10/02/2022 10:11:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers_CorrelationId] ON [dbo].[Customers]
(
	[CorrelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customers_EmailAddress]    Script Date: 10/02/2022 10:11:11 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers_EmailAddress] ON [dbo].[Customers]
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ('81943ef5-6356-4dc2-b14b-8681491151f0') FOR [CustomerRef]
GO
USE [master]
GO
ALTER DATABASE [Customers] SET  READ_WRITE 
GO
