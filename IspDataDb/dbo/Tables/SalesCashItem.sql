CREATE TABLE [dbo].[SalesCashItem] (
    [IdNo]             INT      IDENTITY (1, 1) NOT NULL,
    [SalesJournalIdNo] INT      NOT NULL,
    [Sequence]         INT      NOT NULL,
    [CashCode]         CHAR (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [SaleAmount]       MONEY    CONSTRAINT [DF_SalesDetailItem_SaleAmount] DEFAULT ((0)) NOT NULL,
    [DepositAmount]    MONEY    CONSTRAINT [DF_SalesDetailItem_CashAmount] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SalesDetailItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

