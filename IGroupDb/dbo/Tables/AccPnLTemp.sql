CREATE TABLE [dbo].[AccPnLTemp] (
    [branchID]          VARCHAR (15)    NULL,
    [LedgerID]          VARCHAR (20)    NOT NULL,
    [LedgerNature]      VARCHAR (1)     NOT NULL,
    [year_code]         VARCHAR (4)     NOT NULL,
    [period_code]       VARCHAR (1)     NOT NULL,
    [op_bal]            INT             NOT NULL,
    [budget]            INT             NOT NULL,
    [LedgerNameEnglish] VARCHAR (50)    NULL,
    [LedgerNameArabic]  NVARCHAR (50)   NULL,
    [parentID]          VARCHAR (10)    NULL,
    [parent_name]       VARCHAR (50)    NULL,
    [ac_type]           VARCHAR (1)     NOT NULL,
    [debit]             NUMERIC (38, 2) NULL,
    [credit]            NUMERIC (38, 2) NULL
);

