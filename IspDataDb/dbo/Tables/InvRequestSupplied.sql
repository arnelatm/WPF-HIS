CREATE TABLE [dbo].[InvRequestSupplied] (
    [IdNo]                     INT IDENTITY (1, 1) NOT NULL,
    [InvTransactionDetailIdNo] INT NULL,
    [QtySupplied]              INT NULL,
    CONSTRAINT [PK_InvRequestSupplied] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

