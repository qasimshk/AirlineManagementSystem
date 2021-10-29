USE [FlightDetails]
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Australia', N'AUS')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Austria', N'AUT')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Belgium', N'BEL')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Brazil', N'BRA')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Canada', N'CAN')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'China', N'CHN')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'England', N'ENG')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Germany', N'GER')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Nepal', N'NPl')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'New Zealand', N'NZL')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Portugal', N'POR')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Spain', N'ESP')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'Sweden', N'SWE')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'United Arab Emirates', N'UAE')
GO
INSERT [dbo].[Country] ([CountryName], [CountryCode]) VALUES (N'United States of America', N'USA')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'ABC', N'Heathrow Airport', CAST(985485893 AS Numeric(18, 0)), 43.221, 44.54, N'ENG')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'AKL', N'Auckland Airport', CAST(6492750789 AS Numeric(18, 0)), 37.0082, 174.785, N'NZL')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'DXB', N'Dubai International Airport', CAST(6494544432 AS Numeric(18, 0)), 56.54, 33.33, N'UAE')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'IJK', N'Faro Airport', CAST(844428322 AS Numeric(18, 0)), 67.54, 54.32, N'POR')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'MEL', N'Melbourne Airport', CAST(392971600 AS Numeric(18, 0)), 37.669, 144.841, N'AUS')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'PER', N'Perth Airport', CAST(894788888 AS Numeric(18, 0)), 31.9385, 115.9672, N'AUS')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'PKR', N'Pokhara Airport', CAST(97761465979 AS Numeric(18, 0)), 28.2, 83.9817, N'NPL')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'SYD', N'Sydney Airport', CAST(296679111 AS Numeric(18, 0)), 33.9399, 151.1753, N'AUS')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'TIA', N'Tribhuwan International Airport', CAST(97714113033 AS Numeric(18, 0)), 27.6981, 85.3592, N'NPL')
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [ContactNo], [Longitude], [Latitude], [CountryCode]) VALUES (N'XYZ', N'J F kennedy Airport', CAST(542345433 AS Numeric(18, 0)), 34.43, 23.32, N'USA')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'ABC123', N'TIA', N'SYD', 5500, N'737')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'ABC987', N'PER', N'TIA', 8800, N'777')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'JKL980', N'MEL', N'TIA', 9800, N'779')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'PRA172', N'PER', N'DXB', 7400, N'787')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'QR340', N'PKR', N'IJK', 3500, N'A300')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'STH650', N'PER', N'MEL', 5680, N'A340')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'XCF123', N'ABC', N'AKL', 7600, N'A380')
GO
INSERT [dbo].[Flight] ([FlightNo], [FlightDepartTo], [FlightArriveFrom], [Distance], [PlanModel]) VALUES (N'XYP023', N'XYZ', N'PKR', 5800, N'A390')
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'737', N'Boeing', 5600, 780)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'777', N'Boeing', 10000, 892)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'779', N'Boeing', 17000, 922)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'787', N'Boeing', 15000, 903)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A300', N'Airbus', 13450, 871)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A340', N'Airbus', 12400, 881)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A380', N'Airbus', 15700, 900)
GO
INSERT [dbo].[PlaneModel] ([ModelNumber], [ManufacturerName], [PlaneRange], [CruiseSpeed]) VALUES (N'A390', N'Airbus', 17400, 1081)
GO
