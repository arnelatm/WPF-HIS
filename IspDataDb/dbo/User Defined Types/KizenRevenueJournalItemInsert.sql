CREATE TYPE [dbo].[KizenRevenueJournalItemInsert] AS TABLE
(
    [Sequence] INT NOT NULL,
    [AccountIdNo] INT NOT NULL,
    [Debit] MONEY NOT NULL,
    [Credit] MONEY NOT NULL,
    [RevCostCenterIdNo] INT NOT NULL,
    [Notes] NVARCHAR(300) NULL,
    PRIMARY KEY ([Sequence])
);
GO
