CREATE TABLE [dbo].[CheckDisbursementJournalItem] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [Sequence]         INT            CONSTRAINT [DF_ChequeDisbursementJournalItem_Sequence] DEFAULT ((0)) NOT NULL,
    [AccountIdNo]      INT            CONSTRAINT [DF_ChequeDisbursementJournalItem_AccountIdNo] DEFAULT ((0)) NOT NULL,
    [Debit]            MONEY          CONSTRAINT [DF_ChequeDisbursementJournalItem_Debit] DEFAULT ((0)) NOT NULL,
    [Credit]           MONEY          CONSTRAINT [DF_ChequeDisbursementJournalItem_Credit] DEFAULT ((0)) NOT NULL,
    [Notes]            NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [JournalIdNo]      INT            CONSTRAINT [DF_ChequeDisbursementJournalItem_JournalIdNo] DEFAULT ((0)) NOT NULL,
    [ProfitCenterIdNo] INT            CONSTRAINT [DF_ChequeDisbursementJournalItem_ProfitCenterIdNo] DEFAULT ((0)) NULL,
    [Posted]           BIT            CONSTRAINT [DF_ChequeDisbursementJournalItem_Posted] DEFAULT ((0)) NOT NULL,
    [DateTimeStamp]    ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ChequeDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

