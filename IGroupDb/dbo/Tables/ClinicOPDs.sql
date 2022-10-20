CREATE TABLE [dbo].[ClinicOPDs] (
    [OPDID]          VARCHAR (15)  NOT NULL,
    [DepartmentID]   VARCHAR (15)  NOT NULL,
    [OPDNameEnglish] VARCHAR (75)  NOT NULL,
    [OPDNameArabic]  NVARCHAR (75) NULL,
    [ShortName]      VARCHAR (25)  NULL,
    [OrderNo]        NUMERIC (1)   DEFAULT (1) NULL,
    [AcLedgerID]     VARCHAR (15)  NULL,
    [CostCentre]     VARCHAR (15)  NULL,
    [Active]         INT           DEFAULT (1) NULL,
    [Remark]         VARCHAR (100) NULL,
    [UserID]         VARCHAR (15)  NULL,
    [Create_Date]    DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]      VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ClinicOPDs]
    ON [dbo].[ClinicOPDs]([OPDID] ASC, [DepartmentID] ASC);

