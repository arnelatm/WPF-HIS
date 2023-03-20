CREATE TABLE [dbo].[DrugSale] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [SaleDate]        DATE         NOT NULL,
    [GTIN]            VARCHAR (14) NOT NULL,
    [Expiry]          DATE         NOT NULL,
    [BatchNo]         VARCHAR (20) NOT NULL,
    [SerializationNo] VARCHAR (20) NOT NULL,
    [DateTimeStamp]   ROWVERSION   NULL,
    CONSTRAINT [PK_DrugSale] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DrugSale]
    ON [dbo].[DrugSale]([GTIN] ASC, [Expiry] ASC, [SerializationNo] ASC);

