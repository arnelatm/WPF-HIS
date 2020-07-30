CREATE TABLE [dbo].[ArJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          INT            CONSTRAINT [DF_ArJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_ArJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       INT            CONSTRAINT [DF_ArJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_ArJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_ArJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] INT            CONSTRAINT [DF_ArJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]            BIT            CONSTRAINT [DF_ArJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ArJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





