CREATE TABLE [dbo].[CostCentre] (
    [BranchID]            VARCHAR (15)  NOT NULL,
    [AccountID]           VARCHAR (15)  NOT NULL,
    [CCNameEnglish]       VARCHAR (50)  NOT NULL,
    [CCNameArabic]        NVARCHAR (50) NULL,
    [AcSalesLedgerID]     VARCHAR (15)  NULL,
    [AcCOGSLedgerID]      VARCHAR (15)  NULL,
    [AcInventoryLedgerID] VARCHAR (15)  NULL,
    [AcDepartmentID]      VARCHAR (15)  NULL,
    [Remark]              VARCHAR (300) NULL,
    [UserID]              VARCHAR (15)  NULL,
    [Create_Date]         DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]           VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_CostCentre]
    ON [dbo].[CostCentre]([AccountID] ASC);

