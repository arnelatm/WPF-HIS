CREATE TABLE [dbo].[PurchaseOrderSupplied] (
    [IdNo]                    INT             IDENTITY (1, 1) NOT NULL,
    [PurchaseOrderDetailIdNo] INT             NULL,
    [QtySupplied]             DECIMAL (12, 4) NULL,
    CONSTRAINT [PK_PurchaseOrderSuppliedSupplied] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

