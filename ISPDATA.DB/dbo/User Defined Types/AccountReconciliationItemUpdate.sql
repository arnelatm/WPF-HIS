CREATE TYPE [dbo].[AccountReconciliationItemUpdate] AS TABLE (
    [AccountReconciliationIdNo] INT      NULL,
    [Cleared]                   BIT      NULL,
    [IdNo]                      INT      NOT NULL,
    [JournalCode]               CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalItemIdNo]           INT      NULL,
    [Sequence]                  INT      NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

