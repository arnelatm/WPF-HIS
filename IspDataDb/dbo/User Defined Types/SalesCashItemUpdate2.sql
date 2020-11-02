CREATE TYPE [dbo].[SalesCashItemUpdate2] AS TABLE (
    [CashCode]         CHAR (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DepositAmount]    MONEY    NULL,
    [IDNo]             INT      NOT NULL,
    [SaleAmount]       MONEY    NULL,
    [SalesJournalIdNo] INT      NOT NULL,
    [Sequence]         INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

