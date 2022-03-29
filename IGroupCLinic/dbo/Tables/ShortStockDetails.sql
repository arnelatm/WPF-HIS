CREATE TABLE [dbo].[ShortStockDetails] (
    [BranchID]   VARCHAR (15) NOT NULL,
    [RowNbr]     NUMERIC (5)  NOT NULL,
    [TransDate]  VARCHAR (10) NOT NULL,
    [Item_Code]  VARCHAR (15) NULL,
    [Recover]    CHAR (1)     DEFAULT ('N') NULL,
    [CreateDate] DATETIME     DEFAULT (getdate()) NULL,
    [UserID]     VARCHAR (10) NULL,
    [machineId]  VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_ShortStockDetails]
    ON [dbo].[ShortStockDetails]([BranchID] ASC, [RowNbr] ASC, [UserID] ASC);

