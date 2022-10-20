CREATE TABLE [dbo].[AccStaffExpenseAccount] (
    [BranchID]         VARCHAR (15)    NULL,
    [FinYear]          VARCHAR (4)     NULL,
    [TransNo]          NUMERIC (10)    NULL,
    [StaffID]          VARCHAR (15)    NULL,
    [VDate]            VARCHAR (10)    NULL,
    [CostCentreID]     VARCHAR (15)    NULL,
    [Amount]           NUMERIC (12, 2) NULL,
    [EntryDescription] VARCHAR (100)   NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        NULL,
    [MachineID]        VARCHAR (20)    NULL
);

