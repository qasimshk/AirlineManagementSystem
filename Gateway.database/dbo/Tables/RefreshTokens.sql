CREATE TABLE [dbo].[RefreshTokens] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (450) NULL,
    [Token]      NVARCHAR (MAX) NULL,
    [JwtId]      NVARCHAR (MAX) NULL,
    [IsUsed]     BIT            NOT NULL,
    [IsRevorked] BIT            NOT NULL,
    [AddedDate]  DATETIME2 (7)  NOT NULL,
    [ExpiryDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_RefreshTokens] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RefreshTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_RefreshTokens_UserId]
    ON [dbo].[RefreshTokens]([UserId] ASC);

