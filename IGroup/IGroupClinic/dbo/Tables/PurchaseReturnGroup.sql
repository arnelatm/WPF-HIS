CREATE TABLE [dbo].[PurchaseReturnGroup] (
    [Trans_Key]      INT             NOT NULL,
    [BranchID]       VARCHAR (15)    NOT NULL,
    [WarehouseID]    VARCHAR (15)    NOT NULL,
    [SupplierID]     VARCHAR (15)    NOT NULL,
    [TransNo]        NUMERIC (10)    NOT NULL,
    [TransType]      VARCHAR (10)    NOT NULL,
    [TransDate]      VARCHAR (10)    NULL,
    [ReturnType]     VARCHAR (1)     DEFAULT ('1') NULL,
    [PurchaseNo]     NUMERIC (10)    NULL,
    [SaleAmount]     NUMERIC (12, 2) NULL,
    [CostAmount]     NUMERIC (12, 2) NULL,
    [PostInStock]    VARCHAR (1)     DEFAULT ('N') NULL,
    [PostInAccounts] VARCHAR (1)     DEFAULT ('N') NULL,
    [Reference]      VARCHAR (50)    NULL,
    [Remarks]        TEXT            NULL,
    [UserID]         VARCHAR (15)    NULL,
    [Create_Date]    DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]      VARCHAR (20)    NULL,
    [VATAmt]         NUMERIC (10, 2) DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PurchaseReturnGroup]
    ON [dbo].[PurchaseReturnGroup]([Trans_Key] ASC, [TransNo] ASC);

