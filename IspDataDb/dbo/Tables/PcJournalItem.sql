CREATE TABLE [dbo].[PcJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT       CONSTRAINT [DF_PcJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_PcJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       SMALLINT       CONSTRAINT [DF_PcJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_PcJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_PcJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] SMALLINT       CONSTRAINT [DF_PcJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [PayIdNo]           INT            NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [OldAccountIdNo]    SMALLINT       NULL,
    [Posted]            BIT            CONSTRAINT [DF_PcJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_PcJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





