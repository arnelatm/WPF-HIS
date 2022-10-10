CREATE TABLE [dbo].[Reconciled] (
    [IdNo]               INT      IDENTITY (1, 1) NOT NULL,
    [JournalCode]        CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [JournalItemIdNo]    INT      NOT NULL,
    [ReconciliationIdNo] INT      NOT NULL,
    CONSTRAINT [PK_Reconciled] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

