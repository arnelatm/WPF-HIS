CREATE TABLE [dbo].[ErJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT       CONSTRAINT [DF_ErJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_ErJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       SMALLINT       CONSTRAINT [DF_ErJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_ErJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_ErJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] SMALLINT       CONSTRAINT [DF_ErJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [Notes]             NVARCHAR (300) NULL,
    [Posted]            BIT            CONSTRAINT [DF_ErJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ErJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







