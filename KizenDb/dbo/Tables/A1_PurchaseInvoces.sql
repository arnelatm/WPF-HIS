CREATE TABLE [dbo].[A1_PurchaseInvoces] (
    [ID]                  INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceID]           NVARCHAR (400)  NULL,
    [Date]                DATE            NULL,
    [SupplierID]          NVARCHAR (50)   NULL,
    [Comment]             NVARCHAR (MAX)  NULL,
    [Time]                TIME (0)        NULL,
    [UserName]            NVARCHAR (50)   NULL,
    [BoxID]               NVARCHAR (50)   NULL,
    [StoreID]             INT             NULL,
    [LastEditDateTime]    DATETIME        NULL,
    [LastEditUserName]    NVARCHAR (255)  NULL,
    [SourceType]          NVARCHAR (50)   NULL,
    [SourceID]            INT             NULL,
    [GeneralDiscount]     DECIMAL (19, 4) NULL,
    [GeneralDiscountType] INT             NULL,
    [StoreSerialNumber]   INT             NULL,
    [DueDate]             DATE            NULL,
    [IsReturn]            BIT             CONSTRAINT [DF_A1_PurchaseInvoces_IsReturn] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_A1_PurchaseInvoces] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces]
    ON [dbo].[A1_PurchaseInvoces]([ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces_Date]
    ON [dbo].[A1_PurchaseInvoces]([Date] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces_InvoiceID]
    ON [dbo].[A1_PurchaseInvoces]([InvoiceID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces_Store]
    ON [dbo].[A1_PurchaseInvoces]([StoreID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces_StoreID]
    ON [dbo].[A1_PurchaseInvoces]([StoreID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvoces_SupplierID]
    ON [dbo].[A1_PurchaseInvoces]([SupplierID] ASC);

