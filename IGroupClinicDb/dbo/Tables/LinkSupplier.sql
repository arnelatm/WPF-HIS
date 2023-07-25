CREATE TABLE [dbo].[LinkSupplier] (
    [IdNo]                INT           IDENTITY (1, 1) NOT NULL,
    [SupplierId]          INT           NULL,
    [SupplierIdNo]        INT           NULL,
    [SupplierNameEnglish] VARCHAR (100) NULL,
    CONSTRAINT [PK_LinkSupplier] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

