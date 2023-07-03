CREATE TABLE [dbo].[PMRMedicineDetails] (
    [IdNo]          INT             IDENTITY (1, 1) NOT NULL,
    [Group_Key]     BIGINT          NOT NULL,
    [RowNBR]        INT             NOT NULL,
    [Item_Code]     VARCHAR (15)    NULL,
    [Qty]           NUMERIC (5)     CONSTRAINT [DF__PMRMedicine__Qty__40306ADC] DEFAULT ((1)) NULL,
    [Unit]          CHAR (1)        CONSTRAINT [DF__PMRMedicin__Unit__41248F15] DEFAULT ('B') NULL,
    [SalePrice]     NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__SaleP__4218B34E] DEFAULT ((0)) NULL,
    [DiscountPer]   NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Disco__430CD787] DEFAULT ((0)) NULL,
    [DiscountAmt]   NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Disco__4400FBC0] DEFAULT ((0)) NULL,
    [DeductibleAmt] NUMERIC (10, 2) CONSTRAINT [DF__PMRMedici__Deduc__44F51FF9] DEFAULT ((0)) NULL,
    [Days]          VARCHAR (15)    NULL,
    [DosageID]      VARCHAR (100)   NULL,
    [LabelPrinted]  BIT             NULL,
    CONSTRAINT [PK_PMRMedicineDetails] PRIMARY KEY NONCLUSTERED ([IdNo] ASC)
);




GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRMedicineDetails]
    ON [dbo].[PMRMedicineDetails]([Group_Key] ASC, [RowNBR] ASC);

