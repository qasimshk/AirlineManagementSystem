Create Database Payments

ALTER DATABASE [Payments] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Payments] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Payments] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Payments] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Payments] SET ARITHABORT OFF 
GO
ALTER DATABASE [Payments] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Payments] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Payments] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Payments] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Payments] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Payments] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Payments] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Payments] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Payments] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Payments] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Payments] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Payments] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Payments] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Payments] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Payments] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Payments] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Payments] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Payments] SET RECOVERY FULL 
GO
ALTER DATABASE [Payments] SET  MULTI_USER 
GO
ALTER DATABASE [Payments] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Payments] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Payments] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Payments] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Payments] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Payments] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Payments', N'ON'
GO
ALTER DATABASE [Payments] SET QUERY_STORE = OFF
GO
USE [Payments]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2022 10:22:53 AM ******/
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
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/02/2022 10:22:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionRef] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[Amount] [float] NOT NULL,
	[CorrelationId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211029090238_InitialCommit', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (1, N'c1932cdb-c435-4c70-96f4-a0293980eed7', N'316d8c3c-217a-4fba-beb9-afff9521393d', 75, N'31a1df72-5abf-438c-a6fd-559be2d99b65')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (2, N'071d65e7-5ceb-4617-9a60-e79ca26f2144', N'704f10b7-6ef1-41c6-95c8-1dfe929ab80a', 57, N'df756d27-25a9-427c-bdac-a3c44b167cd0')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (3, N'7b36b7bb-271d-40ed-8b9a-90cc824e2fd6', N'80e0be26-bc48-414b-b3d0-039ed540f603', 68, N'da6b4ac6-30c3-4994-911e-e093479b374c')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (4, N'87de98e8-9adc-45f8-970f-cc001c6a5cbc', N'fe6b4798-0051-48c1-b9c9-31d976b4ca00', 16, N'7c1fd37d-de63-46da-8500-786308724b07')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (5, N'e47b1a59-0f25-4cd7-b2df-89cc034f6374', N'25a2d978-6d4c-4fc9-9e5d-b23aba73c8dc', 82, N'c45eff62-3e0f-4352-9fb4-193024722305')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (6, N'44733cc2-2921-47ca-a600-22d156446523', N'bc05682d-663d-43f3-9421-7d00629f0e3f', 83, N'03aed021-b67f-44eb-808f-cdbbb40434e6')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (7, N'1c168b7b-c49c-484d-9951-4bfded612133', N'c976769e-69bf-48d1-83a0-f3baf7e5ae27', 78, N'c41a077c-bcb9-4362-ad45-23a169cc452d')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (8, N'07b87a24-af61-49a6-b4e4-f0ca13640230', N'184ac2e1-fc48-4832-865d-dbd8997d81bf', 51, N'97a9e3dd-6108-470e-bad4-b2d8a2dc2949')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (9, N'bd0e53ec-0540-4f98-be66-b25a087be078', N'0c18f876-6802-4ae7-ba25-902d2800ba03', 13, N'e582db64-c878-4974-9606-0db6012e0b50')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (10, N'a9296451-53fd-4f74-bbf7-4b6ed92bf5f3', N'5a9d1fb7-0024-485d-9d0b-6b6effa9e8a6', 49, N'454e1e3a-feb4-42b2-9467-15d9d15fa65f')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (11, N'e6d0719e-0cb6-4648-916a-ca533bd78826', N'a508dca7-8eeb-40f3-a3f8-24f701360fdb', 54, N'6472307d-4c82-4f7f-a020-bb74e7398f3f')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (12, N'5ed564fb-b352-465a-8918-c8996fc48ecf', N'0c61c582-6ddf-4931-8a34-7729271d164a', 35, N'2a4328c2-a006-489d-93de-a59f0b28158b')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (13, N'e937983b-f801-4ee9-905c-c506259e794b', N'e3b57d6f-9b14-402e-8148-aea5b90e0194', 58, N'227bf1d8-f610-4078-983e-9bf8bd7288fd')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (14, N'78ebaf94-48b4-42fc-8d67-3587bfab661f', N'169a3c67-057d-4545-a631-915655949ea7', 47, N'e457e471-e87f-4e2f-a745-077be19bbebd')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (15, N'76b25fd0-55b1-4e19-af3a-e020ec4810e4', N'2bc1e6bb-bf86-4b65-bd4b-1becdc389415', 48, N'd8410aba-1a7e-4f08-805a-8dc437f8c102')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (16, N'21726c93-0153-4229-829b-90cb108f9653', N'c5117b70-9260-486f-8aad-3df437150c73', 93, N'd404b1fb-b1da-4e19-8f5d-6fc454c1c506')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (17, N'abb90500-5d6a-46ef-8521-3c95c41c5161', N'e0b071ac-8d76-48d8-aab8-479c422f6c2c', 69, N'f0896193-8184-4b9c-8d34-fc6794e4d67e')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (18, N'f2d67fb6-f1cf-451e-b217-83c793698b09', N'3a963d47-dd1e-42ac-ad42-f961664f8e0e', 17, N'e04de114-a4a6-40e6-a8f8-efc6c0aad694')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (19, N'6789663a-00db-4818-8c94-74c155c88e19', N'dcac787f-a412-4b00-a17e-2eeba184425b', 76, N'eac6832f-a8b4-4644-a10e-bc444616a6e6')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (20, N'c50e2522-15c1-4d73-a637-0fd0b3bfead3', N'592ab148-d8f6-4e01-b110-127c3398d0e4', 89, N'61fc5709-f852-4d58-a180-1374030812c8')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (21, N'a0713715-c6f4-4cf0-bcb8-c8b61effda1f', N'd7a193d4-49ba-40ee-8ece-5799798408af', 21, N'78e90d92-f12d-422b-b61f-16426dad7114')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (22, N'd5761c28-18aa-4a0b-99ca-7a826c9fe99f', N'a25e2e32-f3ee-4ab1-b5fd-7062775250e3', 20, N'd8324d32-fdea-4c6d-bc2f-0dc4e4a5ce0e')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (23, N'53e1a145-a84e-4a05-afc9-10ded1869b2f', N'c38a42be-03f3-4065-a560-9e6bf7fecc44', 87, N'40e4b629-9d4a-4fc2-affa-ffd51f8e4dfd')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (24, N'97deff64-9977-4d10-9c3b-755336846b6c', N'c811a177-fc27-461f-8d49-b59a2c683b11', 72, N'5933c2c0-95b4-4b54-81b3-0ff6a18ee514')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (25, N'1bd756d0-af5f-4b71-9256-1844890025d2', N'b50ab965-b580-49be-add3-6987a00afe06', 68, N'0ee406a5-eba3-4ab0-a8aa-93b8875b1c11')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (26, N'e47c0001-150c-4f63-a6b7-d645e0a608ed', N'e912c9cd-ae9f-4651-861c-d1d1b1dca1bb', 41, N'f11fce24-cd8e-4bad-9e6d-1b5f1b1d9d7b')
INSERT [dbo].[Transactions] ([Id], [TransactionRef], [OrderId], [Amount], [CorrelationId]) VALUES (27, N'ab8f6f7c-19a8-4f6e-ace7-f83c61eacaba', N'6cbf5dce-8cc5-45ac-9146-145400153ac0', 57, N'7614c297-b450-4c9b-a40a-5d60a351635b')
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
/****** Object:  Index [IX_Transactions_CorrelationId]    Script Date: 10/02/2022 10:22:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_CorrelationId] ON [dbo].[Transactions]
(
	[CorrelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Payments] SET  READ_WRITE 
GO
