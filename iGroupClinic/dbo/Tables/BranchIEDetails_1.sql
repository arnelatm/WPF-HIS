CREATE TABLE [dbo].[BranchIEDetails] (
    [Trans_Key]   BIGINT          NOT NULL,
    [BranchID]    VARCHAR (15)    NOT NULL,
    [TransNo]     NUMERIC (10)    NOT NULL,
    [TransType]   CHAR (1)        DEFAULT ('P') NULL,
    [TransDate]   VARCHAR (10)    NOT NULL,
    [AcCode]      VARCHAR (15)    NULL,
    [Amount]      NUMERIC (10, 2) NULL,
    [Description] NVARCHAR (100)  NULL,
    [Remarks]     NVARCHAR (150)  NULL,
    [PostInAc]    CHAR (1)        DEFAULT ('N') NULL,
    [UserID]      VARCHAR (15)    NULL,
    [Create_Date] DATETIME        DEFAULT (getdate()) NULL,
    [machineId]   VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE CLUSTERED INDEX [IDX_BranchIEDetails]
    ON [dbo].[BranchIEDetails]([BranchID] ASC, [TransNo] ASC);

