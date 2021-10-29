CREATE TABLE [dbo].[Customers] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [CustomerRef]   UNIQUEIDENTIFIER DEFAULT ('81943ef5-6356-4dc2-b14b-8681491151f0') NOT NULL,
    [FirstName]     NVARCHAR (20)    NOT NULL,
    [LastName]      NVARCHAR (20)    NOT NULL,
    [EmailAddress]  NVARCHAR (30)    NOT NULL,
    [CorrelationId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers_CorrelationId]
    ON [dbo].[Customers]([CorrelationId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customers_EmailAddress]
    ON [dbo].[Customers]([EmailAddress] ASC);

