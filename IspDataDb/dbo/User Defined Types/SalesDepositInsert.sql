CREATE TYPE [dbo].[SalesDepositInsert] AS TABLE (
    [PaymentTypeIdNo]  TINYINT NOT NULL,
    [DepositAmount]    MONEY   NULL,
    [SaleAmount]       MONEY   NULL,
    [SalesJournalIdNo] INT     NULL,
    [Sequence]         INT     NOT NULL);

