CREATE TABLE [dbo].[PMRCronicDetails] (
    [Series]         VARCHAR (2)     NOT NULL,
    [RegistrationNo] NUMERIC (10)    NOT NULL,
    [Item_Code]      VARCHAR (15)    NULL,
    [DepartmentID]   VARCHAR (15)    NULL,
    [DoctorID]       VARCHAR (15)    NOT NULL,
    [RowNBR]         INT             NOT NULL,
    [Qty]            NUMERIC (5)     DEFAULT (1) NULL,
    [Unit]           CHAR (1)        DEFAULT ('B') NULL,
    [SalePrice]      NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountPer]    NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountAmt]    NUMERIC (10, 2) DEFAULT (0) NULL,
    [Days]           VARCHAR (15)    NULL,
    [DosageID]       VARCHAR (15)    NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRCronicDetails]
    ON [dbo].[PMRCronicDetails]([DoctorID] ASC, [Series] ASC, [RegistrationNo] ASC, [RowNBR] ASC);

