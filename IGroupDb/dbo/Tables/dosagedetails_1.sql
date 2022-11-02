CREATE TABLE [dbo].[dosagedetails] (
    [Group_Key]     BIGINT          NOT NULL,
    [RowNBR]        INT             NOT NULL,
    [Item_Code]     VARCHAR (15)    NULL,
    [Qty]           NUMERIC (5)     NULL,
    [Unit]          CHAR (1)        NULL,
    [SalePrice]     NUMERIC (10, 2) NULL,
    [DiscountPer]   NUMERIC (10, 2) NULL,
    [DiscountAmt]   NUMERIC (10, 2) NULL,
    [DeductibleAmt] NUMERIC (10, 2) NULL,
    [Days]          VARCHAR (15)    NULL,
    [DosageID]      VARCHAR (100)   NULL
);

