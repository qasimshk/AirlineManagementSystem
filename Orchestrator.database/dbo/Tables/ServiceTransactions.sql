CREATE TABLE [dbo].[ServiceTransactions] (
    [CorrelationId]    UNIQUEIDENTIFIER NOT NULL,
    [CurrentState]     NVARCHAR (64)    NULL,
    [CustomerId]       NVARCHAR (MAX)   NULL,
    [OrderId]          NVARCHAR (MAX)   NULL,
    [PaymentId]        NVARCHAR (MAX)   NULL,
    [TicketPrice]      FLOAT (53)       DEFAULT ((0.0000000000000000e+000)) NOT NULL,
    [JsonOrderRequest] NVARCHAR (MAX)   NULL,
    [CreatedOn]        DATETIME2 (7)    NULL,
    [FailedOn]         DATETIME2 (7)    NULL,
    [ErrorMessage]     NVARCHAR (MAX)   NULL,
    [TicketNumber]     NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_ServiceTransactions] PRIMARY KEY CLUSTERED ([CorrelationId] ASC)
);

