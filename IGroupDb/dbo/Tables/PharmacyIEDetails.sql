CREATE TABLE [dbo].[PharmacyIEDetails] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [TransNo]     NUMERIC (10)    NOT NULL,
    [TransDate]   VARCHAR (10)    NOT NULL,
    [AcCode]      VARCHAR (15)    NULL,
    [Amount]      NUMERIC (10, 2) NULL,
    [TransType]   CHAR (1)        DEFAULT ('P') NULL,
    [Description] VARCHAR (100)   NULL,
    [PostInAc]    CHAR (1)        DEFAULT ('N') NULL,
    [CreateDate]  DATETIME        DEFAULT (getdate()) NULL,
    [UserID]      VARCHAR (10)    NULL,
    [machineId]   VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PharmacyIEDetails]
    ON [dbo].[PharmacyIEDetails]([BranchID] ASC, [TransNo] ASC);

