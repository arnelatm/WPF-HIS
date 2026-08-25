CREATE TABLE [dbo].[AccountReconciliationItem] (
    [IdNo]                      INT      IDENTITY (1, 1) NOT NULL,
    [AccountReconciliationIdNo] INT      NULL,
    [JournalCode]               CHAR (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [JournalItemIdNo]           INT      NULL,
    [Cleared]                   BIT      NULL,
    [Sequence]                  INT      NULL,
    CONSTRAINT [PK_AccountReconciliationDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_AccountReconciliationItem_AccountReconciliation]
        FOREIGN KEY ([AccountReconciliationIdNo])
        REFERENCES [dbo].[AccountReconciliation] ([IdNo])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_AccountReconciliationItem_ReconciliationJournalLine]
    ON [dbo].[AccountReconciliationItem] ([AccountReconciliationIdNo] ASC, [JournalCode] ASC, [JournalItemIdNo] ASC)
    WHERE [AccountReconciliationIdNo] IS NOT NULL
      AND [JournalCode] IS NOT NULL
      AND [JournalItemIdNo] IS NOT NULL;

GO
CREATE NONCLUSTERED INDEX [IX_AccountReconciliationItem_ReconciliationCleared]
    ON [dbo].[AccountReconciliationItem] ([AccountReconciliationIdNo] ASC, [Cleared] ASC);

