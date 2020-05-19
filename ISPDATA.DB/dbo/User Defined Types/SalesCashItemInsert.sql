CREATE TYPE [dbo].[SalesCashItemInsert] AS TABLE (
    [CashCode]         CHAR (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DepositAmount]    MONEY    NULL,
    [SaleAmount]       MONEY    NULL,
    [SalesJournalIdNo] INT      NULL,
    [Sequence]         INT      NOT NULL);

