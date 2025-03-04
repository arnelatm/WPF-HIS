CREATE TABLE [dbo].[A1_InvoiceSession] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceID]  INT            NOT NULL,
    [ExpireDate] DATE           NULL,
    [Note]       NVARCHAR (MAX) NULL,
    [Terms]      NVARCHAR (MAX) NULL,
    [Disabled]   BIT            NULL,
    CONSTRAINT [PK_A1_InvoiceSession] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSession_Disabled]
    ON [dbo].[A1_InvoiceSession]([Disabled] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSession_InvoiceID]
    ON [dbo].[A1_InvoiceSession]([InvoiceID] ASC);

