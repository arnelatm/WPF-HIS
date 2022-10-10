CREATE TYPE [dbo].[JournalItemInsert] AS TABLE (
    [AccountIdNo]       INT            NOT NULL,
    [Credit]            MONEY          NOT NULL,
    [Debit]             MONEY          NOT NULL,
    [JournalIDNo]       INT            NOT NULL,
    [Notes]             NVARCHAR (300) NULL,
    [PayIdNo]           INT            NULL,
    [RevCostCenterIdNo] INT            NOT NULL,
    [Sequence]          INT            NOT NULL);

