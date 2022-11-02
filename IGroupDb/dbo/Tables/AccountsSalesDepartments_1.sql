CREATE TABLE [dbo].[AccountsSalesDepartments] (
    [BranchID]              VARCHAR (15)  NOT NULL,
    [DepartmentID]          VARCHAR (15)  NOT NULL,
    [DepartmentNameEnglish] VARCHAR (75)  NULL,
    [DepartmentNameArabic]  VARCHAR (75)  NULL,
    [AcCode]                VARCHAR (15)  NOT NULL,
    [SalesCode]             VARCHAR (15)  NULL,
    [CostOfGoodsCode]       VARCHAR (15)  NULL,
    [InventoryCode]         VARCHAR (15)  NULL,
    [CostCentreID]          VARCHAR (15)  NULL,
    [UserID]                VARCHAR (5)   NOT NULL,
    [Remarks]               VARCHAR (100) NULL,
    [Create_Date]           DATETIME      NULL,
    [MachineID]             VARCHAR (20)  NOT NULL
);

