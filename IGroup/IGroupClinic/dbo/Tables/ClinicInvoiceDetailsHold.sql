CREATE TABLE [dbo].[ClinicInvoiceDetailsHold] (
    [Group_Key]        INT             NOT NULL,
    [InvoiceType]      VARCHAR (2)     NOT NULL,
    [SaleType]         VARCHAR (15)    DEFAULT ('CLINIC INVOICE') NULL,
    [BranchID]         VARCHAR (15)    NOT NULL,
    [RowNbr]           NUMERIC (3)     NOT NULL,
    [ServiceID]        VARCHAR (15)    NOT NULL,
    [Expiry]           VARCHAR (10)    NULL,
    [Qty]              NUMERIC (12, 3) NULL,
    [PcsQty]           NUMERIC (4)     NULL,
    [QtyInStock]       NUMERIC (5)     DEFAULT (0) NULL,
    [EANCode]          VARCHAR (15)    NULL,
    [SalePrice]        NUMERIC (12, 4) DEFAULT (0) NULL,
    [CostPrice]        NUMERIC (12, 4) DEFAULT (0) NULL,
    [costPricePerUnit] NUMERIC (12, 4) DEFAULT (0) NULL,
    [DiscountPer]      NUMERIC (12, 4) DEFAULT (0) NULL,
    [DiscountAmt]      NUMERIC (12, 4) DEFAULT (0) NULL,
    [DeductiblePer]    NUMERIC (12, 4) DEFAULT (0) NULL,
    [DeductibleAmt]    NUMERIC (12, 4) DEFAULT (0) NULL,
    [AgentCommPer]     NUMERIC (12, 2) DEFAULT (0) NULL,
    [SalesManCommPer]  NUMERIC (12, 2) DEFAULT (0) NULL,
    [DepartmentID]     VARCHAR (15)    NULL,
    [Stock_Status]     CHAR (1)        NULL,
    [SBT_Status]       CHAR (1)        NULL,
    [Packed_Stock]     NUMERIC (7, 3)  NULL,
    [DosageID]         VARCHAR (15)    NULL,
    [SaleStatus]       VARCHAR (2)     DEFAULT (null) NULL,
    [VATPercent]       NUMERIC (5, 2)  NULL,
    [VATAmt]           NUMERIC (10, 2) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ClinicInvoiceDetailsHold]
    ON [dbo].[ClinicInvoiceDetailsHold]([Group_Key] ASC, [BranchID] ASC, [RowNbr] ASC);

