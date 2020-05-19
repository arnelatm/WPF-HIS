CREATE TYPE [dbo].[ReconciledInsert] AS TABLE (
    [JournalCode]        CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalItemIdNo]    INT      NULL,
    [ReconciliationIdNo] INT      NULL);

