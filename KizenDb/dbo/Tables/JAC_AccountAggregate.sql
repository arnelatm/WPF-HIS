CREATE TABLE [dbo].[JAC_AccountAggregate] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [AccountId]          INT NOT NULL,
    [AccountAggregateId] INT NOT NULL,
    CONSTRAINT [PK_dbo.JAC_AccountAggregate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AccountAggregate_dbo.JAC_Account_AccountAggregateId] FOREIGN KEY ([AccountAggregateId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_AccountAggregate_dbo.JAC_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[JAC_Account] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountAggregateId]
    ON [dbo].[JAC_AccountAggregate]([AccountAggregateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AccountId]
    ON [dbo].[JAC_AccountAggregate]([AccountId] ASC);

