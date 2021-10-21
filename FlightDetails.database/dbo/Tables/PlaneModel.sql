CREATE TABLE [dbo].[PlaneModel] (
    [ModelNumber]      VARCHAR (10) NOT NULL,
    [ManufacturerName] VARCHAR (50) NOT NULL,
    [PlaneRange]       SMALLINT     NOT NULL,
    [CruiseSpeed]      SMALLINT     NOT NULL,
    CONSTRAINT [ModelN_pk] PRIMARY KEY CLUSTERED ([ModelNumber] ASC)
);

