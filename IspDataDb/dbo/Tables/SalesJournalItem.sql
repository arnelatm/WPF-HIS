CREATE TABLE [dbo].[SalesJournalItem] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]          SMALLINT       CONSTRAINT [DF_SalesJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [JournalIdNo]       INT            CONSTRAINT [DF_SalesJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]       SMALLINT       CONSTRAINT [DF_SalesJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Notes]             NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Debit]             MONEY          CONSTRAINT [DF_SalesJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]            MONEY          CONSTRAINT [DF_SalesJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [RevCostCenterIdNo] SMALLINT       CONSTRAINT [DF_SalesJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [ContactIdNo]       INT             NULL,
    [Posted]            BIT            CONSTRAINT [DF_SalesJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SalesJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);














GO
CREATE NONCLUSTERED INDEX [IX_SalesJournalItemAcIdNo]
    ON [dbo].[SalesJournalItem]([AccountIdNo] ASC);

