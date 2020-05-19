CREATE TYPE [dbo].[AccountReconciliationItemInsert] AS TABLE (
    [AccountReconciliationIdNo] INT      NULL,
    [Cleared]                   BIT      NULL,
    [JournalCode]               CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalItemIdNo]           INT      NULL,
    [Sequence]                  INT      NULL);

