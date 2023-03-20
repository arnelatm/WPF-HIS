CREATE TABLE [dbo].[TransferStockGroup] (
    [BranchID]       VARCHAR (15)    NULL,
    [Trans_Key]      NUMERIC (15)    NOT NULL,
    [WareHouseFrom]  VARCHAR (15)    NOT NULL,
    [WareHouseTo]    VARCHAR (15)    NULL,
    [TransferNo]     NUMERIC (15)    NOT NULL,
    [TransferDate]   VARCHAR (10)    NULL,
    [ReqNo]          VARCHAR (10)    NULL,
    [ReqDate]        VARCHAR (20)    NULL,
    [AcCodeFrom]     VARCHAR (15)    NULL,
    [AcCodeTo]       VARCHAR (15)    NULL,
    [PostInAccounts] CHAR (1)        DEFAULT ('N') NULL,
    [PostInStock]    CHAR (1)        DEFAULT ('N') NULL,
    [amount]         NUMERIC (15, 2) NULL,
    [CostAmount]     NUMERIC (12, 2) NULL,
    [Remarks]        VARCHAR (300)   NULL,
    [Reject]         INT             DEFAULT (0) NULL,
    [RejectDate]     VARCHAR (10)    NULL,
    [UserID]         VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]    DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]      VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_TransferStockGroup]
    ON [dbo].[TransferStockGroup]([BranchID] ASC, [Trans_Key] ASC, [TransferNo] ASC);

