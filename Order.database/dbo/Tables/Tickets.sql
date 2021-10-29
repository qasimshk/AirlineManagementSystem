CREATE TABLE [dbo].[Tickets] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [FlightNumber]     NVARCHAR (MAX)   NOT NULL,
    [DepartureAirport] NVARCHAR (MAX)   NOT NULL,
    [DepartureCountry] NVARCHAR (MAX)   NOT NULL,
    [DepartureDate]    DATETIME2 (7)    NOT NULL,
    [ArrivalAirport]   NVARCHAR (MAX)   NOT NULL,
    [ArrivalCountry]   NVARCHAR (MAX)   NOT NULL,
    [ArrivalDate]      DATETIME2 (7)    NOT NULL,
    [CorrelationId]    UNIQUEIDENTIFIER NOT NULL,
    [OrderRef]         UNIQUEIDENTIFIER NOT NULL,
    [TicketNumber]     NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tickets_CorrelationId]
    ON [dbo].[Tickets]([CorrelationId] ASC);

