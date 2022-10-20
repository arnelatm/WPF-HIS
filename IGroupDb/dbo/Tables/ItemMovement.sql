CREATE TABLE [dbo].[ItemMovement] (
    [BranchID]        VARCHAR (15)    NULL,
    [WarehouseID]     VARCHAR (15)    NULL,
    [TransNo]         NUMERIC (15)    NOT NULL,
    [TransDate]       VARCHAR (10)    NULL,
    [item_code]       VARCHAR (15)    NULL,
    [PCSQty]          NUMERIC (38, 3) NULL,
    [TransType]       VARCHAR (5)     NULL,
    [pack2]           NUMERIC (8)     NULL,
    [pack3]           NUMERIC (8)     NULL,
    [ItemNameEnglish] VARCHAR (50)    NULL,
    [MachineID]       VARCHAR (20)    DEFAULT (host_name()) NULL
);

