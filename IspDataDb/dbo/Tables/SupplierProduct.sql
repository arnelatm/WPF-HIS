CREATE TABLE [dbo].[SupplierProduct] (
    [IdNo]                   INT            IDENTITY (1, 1) NOT NULL,
    [SupplierIdNo]           INT            NOT NULL,
    [ProductIdNo]            INT            NOT NULL,
    [SupplierProductCode]    VARCHAR (10)   NULL,
    [SupplierProductName]    VARCHAR (100)  NULL,
    [SupplierProductNameAra] NVARCHAR (100) NULL,
    CONSTRAINT [PK_SupplierProductCode] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

