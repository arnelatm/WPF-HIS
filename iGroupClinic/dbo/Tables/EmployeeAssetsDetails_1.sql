CREATE TABLE [dbo].[EmployeeAssetsDetails] (
    [Primary_Key] INT          IDENTITY (1, 1) NOT NULL,
    [BranchID]    VARCHAR (15) DEFAULT ('PH001') NULL,
    [EmpID]       VARCHAR (15) NOT NULL,
    [SlNo]        NUMERIC (2)  NULL,
    [AssetsID]    VARCHAR (15) NOT NULL,
    [IssueDate]   VARCHAR (10) DEFAULT (getdate()) NULL,
    [ReturnDate]  VARCHAR (10) NULL,
    [UserID]      VARCHAR (15) DEFAULT ('Admin') NULL,
    [Create_Date] DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]   VARCHAR (20) DEFAULT (host_name()) NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_EmployeeAssetsDetails]
    ON [dbo].[EmployeeAssetsDetails]([BranchID] ASC, [EmpID] ASC, [SlNo] ASC);

