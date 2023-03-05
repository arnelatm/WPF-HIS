CREATE TABLE [dbo].[CdJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT       CONSTRAINT [DF_CashDisbursementJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_CashDisbursementJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       SMALLINT       CONSTRAINT [DF_CashDisbursementJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_CashDisbursementJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_CashDisbursementJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] SMALLINT       CONSTRAINT [DF_CashDisbursementJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [PayIdNo]           INT            NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]            BIT            CONSTRAINT [DF_CashDisbursementJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [OldAccountIdNo]    SMALLINT       NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_CashDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





