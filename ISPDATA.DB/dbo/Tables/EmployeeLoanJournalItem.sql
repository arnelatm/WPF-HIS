CREATE TABLE [dbo].[EmployeeLoanJournalItem] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]         INT            NULL,
    [JournalIdNo]      INT            NOT NULL,
    [AccountIdNo]      INT            NOT NULL,
    [TransactionDate]  DATETIME2 (7)  NULL,
    [Debit]            MONEY          NULL,
    [Credit]           MONEY          NULL,
    [ProfitCenterIdNo] INT            NULL,
    [Notes]            NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]           BIT            NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLoanJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

