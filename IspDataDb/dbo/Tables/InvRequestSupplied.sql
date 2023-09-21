CREATE TABLE [dbo].[InvRequestSupplied] (
    [IdNo]                     INT             IDENTITY (1, 1) NOT NULL,
    [InvTransactionDetailIdNo] INT             NULL,
    [QtySupplied]              DECIMAL (12, 4) NULL,
    CONSTRAINT [PK_InvRequestSupplied] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvRequestSupplied]
    ON [dbo].[InvRequestSupplied]([InvTransactionDetailIdNo] ASC);

