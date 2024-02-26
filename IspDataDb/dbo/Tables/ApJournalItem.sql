CREATE TABLE [dbo].[ApJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          INT            CONSTRAINT [DF_ApJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_ApJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       INT            CONSTRAINT [DF_ApJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]             MONEY          CONSTRAINT [DF_ApJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_ApJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] INT            CONSTRAINT [DF_ApJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [PayIdNo]           INT            NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]            BIT            CONSTRAINT [DF_ApJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_ApJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);












GO
CREATE NONCLUSTERED INDEX [IX_ApJournalItemAcIdNo]
    ON [dbo].[ApJournalItem]([AccountIdNo] ASC);

