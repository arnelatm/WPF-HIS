CREATE TABLE [dbo].[GeneralJournal] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATE           NOT NULL,
    [ReferenceNo]     NVARCHAR (10)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]           NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]          BIT            NULL,
    [ClosingJournal]  BIT            NULL,
    [Cancelled]       BIT            NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_GeneralJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_JournalIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_JournalDate]
    ON [dbo].[GeneralJournal]([TransactionDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_JournalReferenceNo]
    ON [dbo].[GeneralJournal]([ReferenceNo] ASC);

