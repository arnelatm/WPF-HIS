CREATE TABLE [dbo].[Patient_Type] (
    [BranchID]           VARCHAR (15)  NOT NULL,
    [PatientType]        VARCHAR (5)   NOT NULL,
    [DescriptionEnglish] VARCHAR (50)  NOT NULL,
    [DescriptionArabic]  NVARCHAR (50) NULL,
    [BillType]           CHAR (1)      NOT NULL,
    [BillSeries]         VARCHAR (2)   NOT NULL,
    [Series]             VARCHAR (2)   NOT NULL,
    [CompanyTerm]        CHAR (1)      NULL,
    [UserID]             VARCHAR (15)  DEFAULT ('Admin') NULL,
    [Create_Date]        DATETIME      DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)  DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_Patient_Type]
    ON [dbo].[Patient_Type]([BranchID] ASC, [PatientType] ASC);

