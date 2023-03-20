CREATE TABLE [dbo].[HRBankDetails] (
    [BranchID]        VARCHAR (15)    NULL,
    [BankACCode]      VARCHAR (30)    NOT NULL,
    [BankNameEnglish] VARCHAR (75)    NOT NULL,
    [BankNameArabic]  NVARCHAR (75)   NULL,
    [OpeningDate]     VARCHAR (10)    NULL,
    [OPBalance]       NUMERIC (15, 2) NULL,
    [Activate]        INT             NULL,
    [Address1]        VARCHAR (50)    NULL,
    [Address2]        VARCHAR (50)    NULL,
    [Street]          VARCHAR (50)    NULL,
    [City]            VARCHAR (50)    NULL,
    [Country]         VARCHAR (50)    NULL,
    [POBox]           VARCHAR (50)    NULL,
    [ZIP]             VARCHAR (50)    NULL,
    [Phone]           VARCHAR (50)    NULL,
    [Fax]             VARCHAR (30)    NULL,
    [eMailID]         VARCHAR (100)   NULL,
    [Web]             VARCHAR (100)   NULL,
    [UserID]          VARCHAR (15)    NULL,
    [Create_Date]     DATETIME        NULL,
    [MachineID]       VARCHAR (20)    NULL
);

