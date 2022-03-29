CREATE TABLE [dbo].[PMRDentalNotCoveredMedicineDetails] (
    [Group_Key]     BIGINT          NOT NULL,
    [RowNBR]        INT             NOT NULL,
    [Item_Code]     VARCHAR (15)    NULL,
    [Qty]           NUMERIC (5)     DEFAULT (1) NULL,
    [Unit]          CHAR (1)        DEFAULT ('B') NULL,
    [SalePrice]     NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountPer]   NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountAmt]   NUMERIC (10, 2) DEFAULT (0) NULL,
    [DeductibleAmt] NUMERIC (10, 2) DEFAULT (0) NULL,
    [Days]          VARCHAR (15)    NULL,
    [DosageID]      VARCHAR (15)    NULL,
    [UserID]        VARCHAR (15)    NULL,
    [Create_Date]   DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]     VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalNotCoveredMedicineDetails]
    ON [dbo].[PMRDentalNotCoveredMedicineDetails]([Group_Key] ASC, [RowNBR] ASC);

