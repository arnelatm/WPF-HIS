CREATE TYPE [dbo].[EmployeeLoanJournalItemInsert] AS TABLE (
    [JournalIDNo]       INT            NOT NULL,
    [Sequence]          INT            NOT NULL,
    [AccountIdNo]       INT            NOT NULL,
    [Debit]             MONEY          NULL,
    [Credit]            MONEY          NULL,
    [RevCostCenterIdNo] INT            NULL,
    [ContactIdNo]       INT            NOT NULL,
    [Notes]             NVARCHAR (100) NULL);





