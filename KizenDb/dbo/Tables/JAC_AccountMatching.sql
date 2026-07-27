CREATE TABLE [dbo].[JAC_AccountMatching] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [CycleId]          INT             NOT NULL,
    [AccountId]        INT             NOT NULL,
    [CurrencyId]       INT             NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [DateTime]         DATETIME        NOT NULL,
    [Balance]          DECIMAL (19, 4) NOT NULL,
    [Note]             NVARCHAR (250)  NULL,
    [UserId]           INT             NULL,
    [UserName]         NVARCHAR (250)  NULL,
    [UserIdLastEdit]   INT             NULL,
    [UserNameLastEdit] NVARCHAR (250)  NULL,
    CONSTRAINT [PK_dbo.JAC_AccountMatching] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AccountMatching_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AccountMatching_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_AccountMatching_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_AccountMatching]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_AccountMatching]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_AccountMatching]([AccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndCode]
    ON [dbo].[JAC_AccountMatching]([CycleId] ASC, [Code] ASC);

