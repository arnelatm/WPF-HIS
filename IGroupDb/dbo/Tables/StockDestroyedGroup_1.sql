CREATE TABLE [dbo].[StockDestroyedGroup] (
    [BranchID]       VARCHAR (15)    NULL,
    [Primary_Key]    NUMERIC (15)    NOT NULL,
    [BranchFrom]     VARCHAR (15)    NOT NULL,
    [WareHouseFrom]  VARCHAR (15)    NOT NULL,
    [BranchTo]       VARCHAR (15)    NULL,
    [WareHouseTo]    VARCHAR (15)    NULL,
    [TransType]      VARCHAR (10)    NULL,
    [TransSeries]    VARCHAR (5)     NULL,
    [TransNo]        NUMERIC (15)    NOT NULL,
    [TransDate]      VARCHAR (10)    NULL,
    [ReqNo]          VARCHAR (10)    NULL,
    [ReqDate]        VARCHAR (20)    NULL,
    [AcCodeFrom]     VARCHAR (15)    NULL,
    [AcCodeTo]       VARCHAR (15)    NULL,
    [PostInAccounts] CHAR (1)        DEFAULT ('N') NULL,
    [PostInStock]    CHAR (1)        DEFAULT ('N') NULL,
    [amount]         NUMERIC (15, 2) NULL,
    [remarks]        VARCHAR (300)   NULL,
    [UserID]         VARCHAR (15)    DEFAULT ('Admin') NULL,
    [Create_Date]    DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]      VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_StockDestroyedGroup]
    ON [dbo].[StockDestroyedGroup]([BranchID] ASC, [Primary_Key] ASC, [TransNo] ASC);

