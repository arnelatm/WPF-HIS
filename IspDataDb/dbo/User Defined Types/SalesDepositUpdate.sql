CREATE TYPE [dbo].[SalesDepositUpdate] AS TABLE (
    [PaymentTypeIdNo]  TINYINT NOT NULL,
    [DepositAmount]    MONEY   NULL,
    [IdNo]             INT     NOT NULL,
    [SaleAmount]       MONEY   NULL,
    [SalesJournalIdNo] INT     NOT NULL,
    [Sequence]         INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

