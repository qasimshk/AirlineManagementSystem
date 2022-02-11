CREATE DATABASE Orders

ALTER DATABASE [Orders] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Orders] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Orders] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Orders] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Orders] SET ARITHABORT OFF 
GO
ALTER DATABASE [Orders] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Orders] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Orders] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Orders] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Orders] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Orders] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Orders] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Orders] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Orders] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Orders] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Orders] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Orders] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Orders] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Orders] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Orders] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Orders] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Orders] SET RECOVERY FULL 
GO
ALTER DATABASE [Orders] SET  MULTI_USER 
GO
ALTER DATABASE [Orders] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Orders] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Orders] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Orders] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Orders] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Orders] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Orders', N'ON'
GO
ALTER DATABASE [Orders] SET QUERY_STORE = OFF
GO
USE [Orders]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/02/2022 10:22:07 AM ******/
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
/****** Object:  Table [dbo].[Tickets]    Script Date: 10/02/2022 10:22:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [nvarchar](max) NOT NULL,
	[DepartureAirport] [nvarchar](max) NOT NULL,
	[DepartureCountry] [nvarchar](max) NOT NULL,
	[DepartureDate] [datetime2](7) NOT NULL,
	[ArrivalAirport] [nvarchar](max) NOT NULL,
	[ArrivalCountry] [nvarchar](max) NOT NULL,
	[ArrivalDate] [datetime2](7) NOT NULL,
	[CorrelationId] [uniqueidentifier] NOT NULL,
	[OrderRef] [uniqueidentifier] NOT NULL,
	[TicketNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211029085640_InitialCommit', N'5.0.11')
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (1, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'31a1df72-5abf-438c-a6fd-559be2d99b65', N'316d8c3c-217a-4fba-beb9-afff9521393d', N'873153746')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (2, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'df756d27-25a9-427c-bdac-a3c44b167cd0', N'704f10b7-6ef1-41c6-95c8-1dfe929ab80a', N'176971758')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (3, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'da6b4ac6-30c3-4994-911e-e093479b374c', N'80e0be26-bc48-414b-b3d0-039ed540f603', N'214564498')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (4, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'7c1fd37d-de63-46da-8500-786308724b07', N'fe6b4798-0051-48c1-b9c9-31d976b4ca00', N'497695608')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (5, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'c45eff62-3e0f-4352-9fb4-193024722305', N'25a2d978-6d4c-4fc9-9e5d-b23aba73c8dc', N'700294330')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (6, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'03aed021-b67f-44eb-808f-cdbbb40434e6', N'bc05682d-663d-43f3-9421-7d00629f0e3f', N'758843707')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (7, N'XYP023', N'J F kennedy Airport', N'United States of America', CAST(N'2021-11-19T00:00:00.0000000' AS DateTime2), N'Pokhara Airport', N'Nepal', CAST(N'2021-11-20T00:00:00.0000000' AS DateTime2), N'c41a077c-bcb9-4362-ad45-23a169cc452d', N'c976769e-69bf-48d1-83a0-f3baf7e5ae27', N'801579399')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (8, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-11-01T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-11-02T00:00:00.0000000' AS DateTime2), N'97a9e3dd-6108-470e-bad4-b2d8a2dc2949', N'184ac2e1-fc48-4832-865d-dbd8997d81bf', N'245173849')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (9, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'e582db64-c878-4974-9606-0db6012e0b50', N'0c18f876-6802-4ae7-ba25-902d2800ba03', N'764719412')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (10, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'454e1e3a-feb4-42b2-9467-15d9d15fa65f', N'5a9d1fb7-0024-485d-9d0b-6b6effa9e8a6', N'848119314')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (11, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'6472307d-4c82-4f7f-a020-bb74e7398f3f', N'a508dca7-8eeb-40f3-a3f8-24f701360fdb', N'963003771')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (12, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'2a4328c2-a006-489d-93de-a59f0b28158b', N'0c61c582-6ddf-4931-8a34-7729271d164a', N'112763880')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (13, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'227bf1d8-f610-4078-983e-9bf8bd7288fd', N'e3b57d6f-9b14-402e-8148-aea5b90e0194', N'282262624')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (14, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'e457e471-e87f-4e2f-a745-077be19bbebd', N'169a3c67-057d-4545-a631-915655949ea7', N'393376700')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (15, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-12-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-12-29T00:00:00.0000000' AS DateTime2), N'd8410aba-1a7e-4f08-805a-8dc437f8c102', N'2bc1e6bb-bf86-4b65-bd4b-1becdc389415', N'106617050')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (16, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-02-09T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-02-10T00:00:00.0000000' AS DateTime2), N'd404b1fb-b1da-4e19-8f5d-6fc454c1c506', N'c5117b70-9260-486f-8aad-3df437150c73', N'752181841')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (17, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'f0896193-8184-4b9c-8d34-fc6794e4d67e', N'e0b071ac-8d76-48d8-aab8-479c422f6c2c', N'373545284')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (18, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'e04de114-a4a6-40e6-a8f8-efc6c0aad694', N'3a963d47-dd1e-42ac-ad42-f961664f8e0e', N'771711569')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (19, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'eac6832f-a8b4-4644-a10e-bc444616a6e6', N'dcac787f-a412-4b00-a17e-2eeba184425b', N'284128646')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (20, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'61fc5709-f852-4d58-a180-1374030812c8', N'592ab148-d8f6-4e01-b110-127c3398d0e4', N'376822985')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (21, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'78e90d92-f12d-422b-b61f-16426dad7114', N'd7a193d4-49ba-40ee-8ece-5799798408af', N'447751508')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (22, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'd8324d32-fdea-4c6d-bc2f-0dc4e4a5ce0e', N'a25e2e32-f3ee-4ab1-b5fd-7062775250e3', N'477031445')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (23, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2021-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2021-10-29T00:00:00.0000000' AS DateTime2), N'40e4b629-9d4a-4fc2-affa-ffd51f8e4dfd', N'c38a42be-03f3-4065-a560-9e6bf7fecc44', N'197638078')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (24, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-11-20T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'5933c2c0-95b4-4b54-81b3-0ff6a18ee514', N'c811a177-fc27-461f-8d49-b59a2c683b11', N'639286066')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (25, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-11-20T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'0ee406a5-eba3-4ab0-a8aa-93b8875b1c11', N'b50ab965-b580-49be-add3-6987a00afe06', N'659352195')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (26, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-11-20T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'f11fce24-cd8e-4bad-9e6d-1b5f1b1d9d7b', N'e912c9cd-ae9f-4651-861c-d1d1b1dca1bb', N'665081078')
INSERT [dbo].[Tickets] ([Id], [FlightNumber], [DepartureAirport], [DepartureCountry], [DepartureDate], [ArrivalAirport], [ArrivalCountry], [ArrivalDate], [CorrelationId], [OrderRef], [TicketNumber]) VALUES (27, N'XCF123', N'Heathrow Airport', N'England', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'Auckland Airport', N'New Zealand', CAST(N'2022-10-29T00:00:00.0000000' AS DateTime2), N'7614c297-b450-4c9b-a40a-5d60a351635b', N'6cbf5dce-8cc5-45ac-9146-145400153ac0', N'088669478')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
/****** Object:  Index [IX_Tickets_CorrelationId]    Script Date: 10/02/2022 10:22:07 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tickets_CorrelationId] ON [dbo].[Tickets]
(
	[CorrelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Orders] SET  READ_WRITE 
GO
