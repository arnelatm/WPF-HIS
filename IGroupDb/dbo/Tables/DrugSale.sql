CREATE TABLE [dbo].[DrugSale] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [SaleDate]        DATE         NULL,
    [GTIN]            VARCHAR (14) NULL,
    [Expiry]          DATE         NULL,
    [BatchNo]         VARCHAR (20) NULL,
    [SerializationNo] VARCHAR (20) NULL,
    [DateTimeStamp]   ROWVERSION   NULL,
    CONSTRAINT [PK_DrugSale] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

