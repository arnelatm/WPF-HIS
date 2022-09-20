CREATE TABLE [dbo].[AccountsGroup] (
    [BranchID]         VARCHAR (15)    NOT NULL,
    [GroupID]          VARCHAR (10)    NOT NULL,
    [GroupNameEnglish] VARCHAR (50)    NOT NULL,
    [GroupNameArabic]  NVARCHAR (50)   NULL,
    [ParentID]         VARCHAR (10)    NOT NULL,
    [PrimaryGroupID]   VARCHAR (10)    NULL,
    [GroupStatus]      BIT             NULL,
    [OpeningBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [ClosingBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [BalanceAmt]       NUMERIC (12, 2) DEFAULT (0) NULL,
    [CreditAmt]        NUMERIC (12, 2) DEFAULT (0) NULL,
    [DebitAmt]         NUMERIC (12, 2) DEFAULT (0) NULL,
    [ThisYearBalance]  NUMERIC (12, 2) DEFAULT (0) NULL,
    [PrevYearBalance]  NUMERIC (12, 2) DEFAULT (0) NULL,
    [ThisQtrBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [PrevQtrBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [Billing]          BIT             NULL,
    [CostCentres]      BIT             NULL,
    [SubLedger]        BIT             NULL,
    [Revenue]          BIT             NULL,
    [GrossProfit]      BIT             NULL,
    [Positive]         BIT             NULL,
    [NegativeBalance]  BIT             NULL,
    [StockAffected]    BIT             NULL,
    [OrderBy]          NUMERIC (5)     NULL,
    [GroupCategory]    NUMERIC (1)     NULL,
    [Remarks]          VARCHAR (300)   NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL,
    [Primary_Key]      INT             IDENTITY (1, 1) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AccountsGroup]
    ON [dbo].[AccountsGroup]([GroupID] ASC);

