CREATE TABLE [dbo].[PMRMedicineNotCoveredDetails] (
    [IdNo]          INT             IDENTITY (1, 1) NOT NULL,
    [Group_Key]     BIGINT          NOT NULL,
    [RowNBR]        INT             NOT NULL,
    [Item_Code]     VARCHAR (15)    NULL,
    [Qty]           NUMERIC (5)     CONSTRAINT [DF__PMRMedicine__Qty__4BA21D88] DEFAULT ((1)) NULL,
    [Unit]          CHAR (1)        CONSTRAINT [DF__PMRMedicin__Unit__4C9641C1] DEFAULT ('B') NULL,
    [SalePrice]     NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__SaleP__4D8A65FA] DEFAULT ((0)) NULL,
    [DiscountPer]   NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Disco__4E7E8A33] DEFAULT ((0)) NULL,
    [DiscountAmt]   NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Disco__4F72AE6C] DEFAULT ((0)) NULL,
    [DeductibleAmt] NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Deduc__5066D2A5] DEFAULT ((0)) NULL,
    [Days]          VARCHAR (15)    NULL,
    [DosageID]      VARCHAR (15)    NULL,
    [LabelPrinted]  BIT             NULL,
    CONSTRAINT [PK_PMRMedicineNotCoveredDetails] PRIMARY KEY NONCLUSTERED ([IdNo] ASC)
);




GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRMedicineNotCoveredDetails]
    ON [dbo].[PMRMedicineNotCoveredDetails]([Group_Key] ASC, [RowNBR] ASC);

