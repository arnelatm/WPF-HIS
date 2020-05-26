CREATE TABLE [dbo].[CashDisbursementJournalItem] (
    [IdNo]             INT            NOT NULL,
    [Sequence]         INT            CONSTRAINT [DF_CashDisbursementJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]      INT            CONSTRAINT [DF_CashDisbursementJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]      INT            CONSTRAINT [DF_CashDisbursementJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]            MONEY          CONSTRAINT [DF_CashDisbursementJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]           MONEY          CONSTRAINT [DF_CashDisbursementJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [ProfitCenterIdNo] INT            CONSTRAINT [DF_CashDisbursementJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]            NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]           BIT            CONSTRAINT [DF_CashDisbursementJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]    ROWVERSION     NOT NULL,
    CONSTRAINT [PK_CashDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



