CREATE TABLE [dbo].[Transactions] (
    [Id]             INT              IDENTITY (1, 1) NOT NULL,
    [TransactionRef] UNIQUEIDENTIFIER NOT NULL,
    [OrderId]        UNIQUEIDENTIFIER NOT NULL,
    [Amount]         FLOAT (53)       NOT NULL,
    [CorrelationId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Transactions_CorrelationId]
    ON [dbo].[Transactions]([CorrelationId] ASC);

