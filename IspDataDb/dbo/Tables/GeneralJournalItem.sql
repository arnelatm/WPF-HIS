CREATE TABLE [dbo].[GeneralJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT       CONSTRAINT [DF_GeneralJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_GeneralJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       SMALLINT       CONSTRAINT [DF_GeneralJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_GeneralJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_GeneralJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] SMALLINT       CONSTRAINT [DF_GeneralJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]            BIT            CONSTRAINT [DF_GeneralJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_GeneralJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











