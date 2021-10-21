CREATE TABLE [dbo].[Country] (
    [CountryName] VARCHAR (50) NOT NULL,
    [CountryCode] CHAR (3)     NOT NULL,
    CONSTRAINT [country_pk] PRIMARY KEY CLUSTERED ([CountryCode] ASC),
    CONSTRAINT [Country_name_uk] UNIQUE NONCLUSTERED ([CountryName] ASC)
);

