CREATE TABLE [dbo].[FinancialYear] (
    [BranchID]               VARCHAR (15)    NOT NULL,
    [YearID]                 VARCHAR (4)     NOT NULL,
    [YearDescriptionEnglish] VARCHAR (50)    NULL,
    [YearDescriptionArabic]  NVARCHAR (50)   NULL,
    [OpeningDate]            VARCHAR (10)    NULL,
    [ClosingDate]            VARCHAR (10)    NULL,
    [CreditAmt]              NUMERIC (14, 2) NULL,
    [DebitAmt]               NUMERIC (14, 2) NULL,
    [LastVoucherDate]        VARCHAR (10)    NULL,
    [YearClosed]             INT             NULL,
    [DefaultYear]            INT             DEFAULT (0) NULL,
    [Remarks]                VARCHAR (150)   NULL,
    [UserID]                 VARCHAR (15)    NULL,
    [Create_Date]            DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]              VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_FinancialYear]
    ON [dbo].[FinancialYear]([BranchID] ASC, [YearID] ASC);

