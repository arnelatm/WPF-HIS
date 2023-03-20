CREATE TABLE [dbo].[BranchDetails] (
    [Primary_Key]       INT           IDENTITY (1, 1) NOT NULL,
    [CompanyCode]       VARCHAR (15)  NOT NULL,
    [branchID]          VARCHAR (15)  NOT NULL,
    [BranchNameEnglish] VARCHAR (50)  NOT NULL,
    [BranchNameArabic]  NVARCHAR (50) NULL,
    [Contact_Person]    NVARCHAR (50) NULL,
    [Designation]       NVARCHAR (50) NULL,
    [Address1]          VARCHAR (50)  NULL,
    [Address2]          VARCHAR (50)  NULL,
    [PO_Box]            VARCHAR (10)  NULL,
    [zip]               VARCHAR (10)  NULL,
    [Street]            VARCHAR (50)  NULL,
    [City]              VARCHAR (50)  NULL,
    [Phone1]            VARCHAR (50)  NULL,
    [Phone2]            VARCHAR (50)  NULL,
    [fax]               VARCHAR (50)  NULL,
    [email]             VARCHAR (50)  NULL,
    [web]               VARCHAR (50)  NULL,
    [CR_no]             VARCHAR (20)  NULL,
    [Zijil_no]          VARCHAR (20)  NULL,
    [AC_Code]           VARCHAR (10)  NULL,
    [Main_branch]       CHAR (1)      DEFAULT ('N') NULL,
    [MainBranchID]      VARCHAR (15)  NOT NULL,
    [ShortName]         VARCHAR (20)  NULL,
    [BranchColor]       VARCHAR (50)  DEFAULT ('Control') NULL,
    [Remark]            VARCHAR (100) NULL,
    [Address1Arabic]    NVARCHAR (50) NULL,
    [Address2Arabic]    NVARCHAR (50) NULL,
    [StreetArabic]      NVARCHAR (50) NULL,
    [CityArabic]        NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BranchDetails]
    ON [dbo].[BranchDetails]([branchID] ASC);

