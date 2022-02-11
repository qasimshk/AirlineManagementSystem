CREATE DATABASE FlightDetails
GO
ALTER DATABASE [FlightDetails] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlightDetails].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlightDetails] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlightDetails] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlightDetails] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlightDetails] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlightDetails] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlightDetails] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlightDetails] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlightDetails] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlightDetails] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlightDetails] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlightDetails] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlightDetails] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlightDetails] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlightDetails] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlightDetails] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FlightDetails] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlightDetails] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlightDetails] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlightDetails] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlightDetails] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlightDetails] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlightDetails] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlightDetails] SET RECOVERY FULL 
GO
ALTER DATABASE [FlightDetails] SET  MULTI_USER 
GO
ALTER DATABASE [FlightDetails] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlightDetails] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlightDetails] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlightDetails] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlightDetails] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlightDetails] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FlightDetails', N'ON'
GO
ALTER DATABASE [FlightDetails] SET QUERY_STORE = OFF
GO
USE [FlightDetails]
GO
/****** Object:  Table [dbo].[PlaneModel]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaneModel](
	[ModelNumber] [varchar](10) NOT NULL,
	[ManufacturerName] [varchar](50) NOT NULL,
	[PlaneRange] [smallint] NOT NULL,
	[CruiseSpeed] [smallint] NOT NULL,
 CONSTRAINT [ModelN_pk] PRIMARY KEY CLUSTERED 
(
	[ModelNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryName] [varchar](50) NOT NULL,
	[CountryCode] [char](3) NOT NULL,
 CONSTRAINT [country_pk] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airport]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airport](
	[AirportCode] [char](3) NOT NULL,
	[AirportName] [varchar](50) NOT NULL,
	[ContactNo] [numeric](18, 0) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[CountryCode] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AirportCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[FlightNo] [varchar](10) NOT NULL,
	[FlightDepartTo] [char](3) NOT NULL,
	[FlightArriveFrom] [char](3) NOT NULL,
	[Distance] [int] NOT NULL,
	[PlanModel] [varchar](10) NULL,
 CONSTRAINT [FlightNo_pk] PRIMARY KEY CLUSTERED 
(
	[FlightNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_FlightDetails]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_FlightDetails] 
AS
   SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT cy.CountryCode FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountryISO,
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		(SELECT cy.CountryCode FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountryISO,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'ABC', N'Heathrow Airport', CAST(985485893 AS Numeric(18, 0)), 43.221, 44.54, N'ENG')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'AKL', N'Auckland Airport', CAST(6492750789 AS Numeric(18, 0)), 37.0082, 174.785, N'NZL')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'DXB', N'Dubai International Airport', CAST(6494544432 AS Numeric(18, 0)), 56.54, 33.33, N'UAE')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'IJK', N'Faro Airport', CAST(844428322 AS Numeric(18, 0)), 67.54, 54.32, N'POR')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'MEL', N'Melbourne Airport', CAST(392971600 AS Numeric(18, 0)), 37.669, 144.841, N'AUS')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'PER', N'Perth Airport', CAST(894788888 AS Numeric(18, 0)), 31.9385, 115.9672, N'AUS')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'PKR', N'Pokhara Airport', CAST(97761465979 AS Numeric(18, 0)), 28.2, 83.9817, N'NPL')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'SYD', N'Sydney Airport', CAST(296679111 AS Numeric(18, 0)), 33.9399, 151.1753, N'AUS')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'TIA', N'Tribhuwan International Airport', CAST(97714113033 AS Numeric(18, 0)), 27.6981, 85.3592, N'NPL')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'XYZ', N'J F kennedy Airport', CAST(542345433 AS Numeric(18, 0)), 34.43, 23.32, N'USA')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Australia', N'AUS')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Austria', N'AUT')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Belgium', N'BEL')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Brazil', N'BRA')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Canada', N'CAN')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'China', N'CHN')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'England', N'ENG')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Germany', N'GER')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Nepal', N'NPl')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'New Zealand', N'NZL')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Portugal', N'POR')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Spain', N'ESP')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Sweden', N'SWE')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'United Arab Emirates', N'UAE')
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'United States of America', N'USA')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'ABC123', N'TIA', N'SYD', 5500, N'737')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'ABC987', N'PER', N'TIA', 8800, N'777')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'JKL980', N'MEL', N'TIA', 9800, N'779')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'PRA172', N'PER', N'DXB', 7400, N'787')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'QR340', N'PKR', N'IJK', 3500, N'A300')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'STH650', N'PER', N'MEL', 5680, N'A340')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'XCF123', N'ABC', N'AKL', 7600, N'A380')
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'XYP023', N'XYZ', N'PKR', 5800, N'A390')
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'737', N'Boeing', 5600, 780)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'777', N'Boeing', 10000, 892)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'779', N'Boeing', 17000, 922)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'787', N'Boeing', 15000, 903)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A300', N'Airbus', 13450, 871)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A340', N'Airbus', 12400, 881)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A380', N'Airbus', 15700, 900)
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A390', N'Airbus', 17400, 1081)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Country_name_uk]    Script Date: 09/02/2022 04:19:26 PM ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [Country_name_uk] UNIQUE NONCLUSTERED 
(
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Airport]  WITH CHECK ADD  CONSTRAINT [CountryCode_fk] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Country] ([CountryCode])
GO
ALTER TABLE [dbo].[Airport] CHECK CONSTRAINT [CountryCode_fk]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FLightArriceFrom_fk] FOREIGN KEY([FlightArriveFrom])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FLightArriceFrom_fk]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FLightDepartTo_fk] FOREIGN KEY([FlightDepartTo])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FLightDepartTo_fk]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FlightArriveFrom] CHECK  (([FlightArriveFrom]<>[FlightDepartTo]))
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FlightArriveFrom]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllFlights]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllFlights]
AS
BEGIN
   SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFlightByDestination]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_GetFlightByDestination]  
  @Departure VARCHAR(3),
  @Arrival VARCHAR(3)
  AS
  BEGIN

  DECLARE @DepartureAirport VARCHAR(10)
  DECLARE @ArrivalAirport VARCHAR(10)

  SELECT TOP 1 @DepartureAirport = AirportCode FROM Airport WHERE CountryCode = @Departure
  SELECT  TOP 1 @ArrivalAirport = AirportCode FROM Airport WHERE CountryCode = @Arrival

	 SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber
	 WHERE fg.FlightDepartTo = @DepartureAirport AND fg.FlightArriveFrom = @ArrivalAirport
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFlightByFlightNumber]    Script Date: 09/02/2022 04:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_GetFlightByFlightNumber]  
  @FlightNumber VARCHAR(6)  
  AS
  BEGIN

	 SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber
	 WHERE fg.FlightNo=@FlightNumber
  END
GO
USE [master]
GO
ALTER DATABASE [FlightDetails] SET  READ_WRITE 
GO
