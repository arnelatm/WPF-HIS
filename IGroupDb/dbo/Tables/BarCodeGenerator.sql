CREATE TABLE [dbo].[BarCodeGenerator] (
    [RowNBR]          NUMERIC (5)     NULL,
    [Item_Code]       VARCHAR (15)    NULL,
    [Batch]           VARCHAR (15)    NULL,
    [ItemNameEnglish] VARCHAR (100)   NULL,
    [ItemNameArabic]  NVARCHAR (100)  NULL,
    [Price]           NUMERIC (10, 2) CONSTRAINT [DF__BarCodeGe__Price__5DEAEAF5] DEFAULT ((0)) NULL,
    [Qty]             NUMERIC (5)     NULL,
    [Expiry]          VARCHAR (10)    NULL,
    [MachineID]       VARCHAR (30)    NULL,
    [ShortName]       VARCHAR (25)    NULL,
    [PurchaseNo]      NUMERIC (10)    NULL,
    [VATAmt]          NUMERIC (10, 2) NULL
);

