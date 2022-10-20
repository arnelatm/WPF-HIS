CREATE TABLE [dbo].[EmployeeFamilyDetails] (
    [Primary_Key] INT          IDENTITY (1, 1) NOT NULL,
    [BranchID]    VARCHAR (15) DEFAULT ('PH001') NULL,
    [EmpID]       VARCHAR (15) NOT NULL,
    [SlNo]        NUMERIC (2)  NULL,
    [NameEnglish] VARCHAR (40) NULL,
    [Relation]    VARCHAR (20) NULL,
    [DOB]         VARCHAR (10) NULL,
    [Sex]         CHAR (1)     DEFAULT ('M') NULL,
    [Ticket]      CHAR (1)     DEFAULT ('Y') NULL,
    [Insured]     CHAR (1)     DEFAULT ('Y') NULL,
    [InsuranceNo] VARCHAR (20) NULL,
    [Medical]     CHAR (1)     DEFAULT ('Y') NULL,
    [MedicalNo]   VARCHAR (1)  NULL,
    [UserID]      VARCHAR (15) DEFAULT ('Admin') NULL,
    [Create_Date] DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]   VARCHAR (20) DEFAULT (host_name()) NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_EmployeeFamilyDetails]
    ON [dbo].[EmployeeFamilyDetails]([BranchID] ASC, [EmpID] ASC, [SlNo] ASC);

