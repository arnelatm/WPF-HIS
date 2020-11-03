CREATE TYPE [dbo].[SalesCashItemUpdate3] AS TABLE (
    [CashCodeIdNo]     TINYINT NOT NULL,
    [DepositAmount]    MONEY   NULL,
    [IDNo]             INT     NOT NULL,
    [SaleAmount]       MONEY   NULL,
    [SalesJournalIdNo] INT     NOT NULL,
    [Sequence]         INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

