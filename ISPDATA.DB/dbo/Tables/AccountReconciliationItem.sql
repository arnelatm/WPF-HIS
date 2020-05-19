CREATE TABLE [dbo].[AccountReconciliationItem] (
    [IdNo]                      INT      IDENTITY (1, 1) NOT NULL,
    [AccountReconciliationIdNo] INT      NULL,
    [JournalCode]               CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalItemIdNo]           INT      NULL,
    [Cleared]                   BIT      NULL,
    [Sequence]                  INT      NULL,
    CONSTRAINT [PK_AccountReconciliationDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

