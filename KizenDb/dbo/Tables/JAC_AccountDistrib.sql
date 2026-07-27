CREATE TABLE [dbo].[JAC_AccountDistrib] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [AccountId]        INT             NOT NULL,
    [AccountDistribId] INT             NOT NULL,
    [Percent]          DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AccountDistrib] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AccountDistrib_dbo.JAC_Account_AccountDistribId] FOREIGN KEY ([AccountDistribId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AccountDistrib_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountDistribId]
    ON [dbo].[JAC_AccountDistrib]([AccountDistribId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_AccountDistrib]([AccountId] ASC);

