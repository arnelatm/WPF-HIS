CREATE TABLE [dbo].[INJVaccinesUsedList] (
    [BranchID]     VARCHAR (15)    NULL,
    [CostCentreID] VARCHAR (15)    NULL,
    [Item_Code]    VARCHAR (15)    NULL,
    [ServiceID]    VARCHAR (15)    NULL,
    [OpeningQty]   NUMERIC (10, 3) NULL,
    [ClosingQty]   NUMERIC (10, 3) NULL,
    [Dosage]       NUMERIC (2)     NULL,
    [Status]       INT             DEFAULT (1) NULL,
    [UserID]       VARCHAR (15)    NULL,
    [Create_Date]  DATETIME        NULL,
    [MachineID]    VARCHAR (20)    NULL
);

