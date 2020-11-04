CREATE TYPE [dbo].[SalesDepositInsert3] AS TABLE (
    [CashCodeIdNo]     TINYINT NOT NULL,
    [DepositAmount]    MONEY   NULL,
    [SaleAmount]       MONEY   NULL,
    [SalesJournalIdNo] INT     NULL,
    [Sequence]         INT     NOT NULL);

