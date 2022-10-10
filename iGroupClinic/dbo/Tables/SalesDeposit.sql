CREATE TABLE [dbo].[SalesDeposit] (
    [IdNo]             INT      IDENTITY (1, 1) NOT NULL,
    [SalesJournalIdNo] INT      NOT NULL,
    [Sequence]         SMALLINT NOT NULL,
    [DepositTypeIdNo]  SMALLINT NOT NULL,
    [SaleAmount]       MONEY    CONSTRAINT [DF_SalesDetailItem_SaleAmount] DEFAULT ((0)) NOT NULL,
    [DepositAmount]    MONEY    CONSTRAINT [DF_SalesDetailItem_CashAmount] DEFAULT ((0)) NOT NULL,
    [VatAmount]        MONEY    NULL,
    CONSTRAINT [PK_SalesDetailItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

