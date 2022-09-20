CREATE TABLE [dbo].[MedicalDepartmentGroups] (
    [DepartmentGroupID] VARCHAR (15)  NOT NULL,
    [GroupNameEnglish]  VARCHAR (75)  NOT NULL,
    [GroupNameArabic]   NVARCHAR (75) NULL,
    [ShortName]         VARCHAR (25)  NULL,
    [UserID]            VARCHAR (15)  NULL,
    [Create_Date]       DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]         VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_MedicalDepartmentGroups]
    ON [dbo].[MedicalDepartmentGroups]([DepartmentGroupID] ASC);

