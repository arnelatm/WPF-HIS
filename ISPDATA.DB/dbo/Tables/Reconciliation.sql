CREATE TABLE [dbo].[Reconciliation] (
    [IdNo]               BIGINT IDENTITY (1, 1) NOT NULL,
    [ReconciliationDate] DATE   NULL,
    [Cleared]            BIT    NULL,
    [Reconciled]         BIT    NULL,
    CONSTRAINT [PK_Reconciliation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

