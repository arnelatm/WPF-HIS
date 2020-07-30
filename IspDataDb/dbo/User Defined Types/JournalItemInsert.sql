CREATE TYPE [dbo].[JournalItemInsert] AS TABLE (
    [AccountIdNo]       INT            NOT NULL,
    [Credit]            MONEY          NOT NULL,
    [Debit]             MONEY          NOT NULL,
    [JournalIDNo]       INT            NOT NULL,
    [Notes]             NVARCHAR (100) NOT NULL,
    [RevCostCenterIdNo] INT            NOT NULL,
    [Sequence]          INT            NOT NULL);





