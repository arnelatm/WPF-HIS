CREATE TABLE [dbo].[MedicalDepartments] (
    [DepartmentGroupID]     VARCHAR (15)  NOT NULL,
    [DepartmentID]          VARCHAR (15)  NOT NULL,
    [DepartmentNameEnglish] VARCHAR (75)  NOT NULL,
    [DepartmentNameArabic]  NVARCHAR (75) NULL,
    [ShortName]             VARCHAR (25)  NULL,
    [OrderNo]               NUMERIC (1)   DEFAULT (1) NULL,
    [AcLedgerID]            VARCHAR (15)  NULL,
    [CostCentre]            VARCHAR (15)  NULL,
    [UserID]                VARCHAR (15)  NULL,
    [Create_Date]           DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]             VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_MedicalDepartments]
    ON [dbo].[MedicalDepartments]([DepartmentGroupID] ASC, [DepartmentID] ASC);

