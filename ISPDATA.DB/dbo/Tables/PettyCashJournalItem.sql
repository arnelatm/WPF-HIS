CREATE TABLE [dbo].[PettyCashJournalItem] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]         INT            CONSTRAINT [DF_PettyCashJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]      INT            CONSTRAINT [DF_PettyCashJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]      INT            CONSTRAINT [DF_PettyCashJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]            MONEY          CONSTRAINT [DF_PettyCashJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]           MONEY          CONSTRAINT [DF_PettyCashJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [ProfitCenterIdNo] INT            CONSTRAINT [DF_PettyCashJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]            NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]           BIT            CONSTRAINT [DF_PettyCashJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]    ROWVERSION     NOT NULL,
    CONSTRAINT [PK_PettyCashJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

