CREATE TABLE [dbo].[CashReceiptJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          INT            CONSTRAINT [DF_CashReceiptJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_CashReceiptJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       INT            CONSTRAINT [DF_CashReceiptJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_CashReceiptJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_CashReceiptJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] INT            CONSTRAINT [DF_CashReceiptJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]             NVARCHAR (300) NOT NULL,
    [Posted]            BIT            CONSTRAINT [DF_CashReceiptJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_CashReceiptJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









