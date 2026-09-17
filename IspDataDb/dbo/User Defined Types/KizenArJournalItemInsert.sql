CREATE TYPE [dbo].[KizenArJournalItemInsert] AS TABLE
(
    [BatchSequence] INT NOT NULL,
    [Sequence] INT NOT NULL,
    [AccountIdNo] INT NOT NULL,
    [Debit] MONEY NOT NULL,
    [Credit] MONEY NOT NULL,
    [RevCostCenterIdNo] INT NOT NULL,
    [Notes] NVARCHAR (300) NULL
);
