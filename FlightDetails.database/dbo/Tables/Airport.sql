CREATE TABLE [dbo].[Airport] (
    [AirportCode] CHAR (3)     NOT NULL,
    [AirportName] VARCHAR (50) NOT NULL,
    [ContactNo]   NUMERIC (18) NOT NULL,
    [Longitude]   FLOAT (53)   NOT NULL,
    [Latitude]    FLOAT (53)   NOT NULL,
    [CountryCode] CHAR (3)     NOT NULL,
    PRIMARY KEY CLUSTERED ([AirportCode] ASC),
    CONSTRAINT [CountryCode_fk] FOREIGN KEY ([CountryCode]) REFERENCES [dbo].[Country] ([CountryCode])
);

