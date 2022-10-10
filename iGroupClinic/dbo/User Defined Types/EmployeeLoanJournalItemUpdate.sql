CREATE TYPE [dbo].[EmployeeLoanJournalItemUpdate] AS TABLE (
    [IDNo]              INT            NOT NULL,
    [JournalIDNo]       INT            NOT NULL,
    [Sequence]          INT            NOT NULL,
    [AccountIdNo]       INT            NOT NULL,
    [Debit]             MONEY          NULL,
    [Credit]            MONEY          NULL,
    [RevCostCenterIdNo] INT            NULL,
    [Notes]             NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

