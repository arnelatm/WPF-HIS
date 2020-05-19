CREATE TYPE [dbo].[EmployeeLoanJournalItemInsert] AS TABLE (
    [JournalIDNo]      INT            NOT NULL,
    [Sequence]         INT            NOT NULL,
    [AccountIdNo]      INT            NOT NULL,
    [Debit]            MONEY          NULL,
    [Credit]           MONEY          NULL,
    [ProfitCenterIdNo] INT            NULL,
    [Notes]            NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL);

