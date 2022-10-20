CREATE TABLE [dbo].[AccountsBalanceSheet] (
    [BranchID]          VARCHAR (15)    NOT NULL,
    [LedgerID]          VARCHAR (15)    NOT NULL,
    [LevelNo]           NUMERIC (2)     NOT NULL,
    [LedgerNameEnglish] VARCHAR (75)    NULL,
    [LedgerNameArabic]  NVARCHAR (75)   NULL,
    [ParentID]          VARCHAR (15)    NOT NULL,
    [ParentNameEnglish] VARCHAR (75)    NULL,
    [ParentNameArabic]  NVARCHAR (75)   NULL,
    [LedgerType]        VARCHAR (1)     NULL,
    [LedgerOrGroup]     VARCHAR (1)     NULL,
    [Balance]           NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [SlNo]              NUMERIC (5)     DEFAULT ((1)) NULL,
    [TotalAssets]       NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [TotalLiability]    NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [TotalCapital]      NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [TotalPnL]          NUMERIC (10, 2) DEFAULT ((0)) NULL,
    [UserID]            VARCHAR (15)    NULL,
    [Create_Date]       DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]         VARCHAR (20)    DEFAULT (host_name()) NULL
);

