CREATE TABLE [dbo].[AccountsVoucherDetails] (
    [BranchID]         VARCHAR (15)    NOT NULL,
    [Group_Key]        NUMERIC (10)    NOT NULL,
    [SlNo]             NUMERIC (4)     NOT NULL,
    [DrCr]             VARCHAR (1)     NOT NULL,
    [LedgerID]         VARCHAR (15)    NOT NULL,
    [CostCentreID]     VARCHAR (5)     NOT NULL,
    [DrAmt]            NUMERIC (15, 2) NOT NULL,
    [CrAmt]            NUMERIC (15, 2) NOT NULL,
    [Status]           VARCHAR (1)     NOT NULL,
    [Ref]              NVARCHAR (20)   NULL,
    [EntryDescription] NVARCHAR (500)  NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AccountsVoucherDetails]
    ON [dbo].[AccountsVoucherDetails]([BranchID] ASC, [Group_Key] ASC, [SlNo] ASC);

