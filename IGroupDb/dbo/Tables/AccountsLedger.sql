CREATE TABLE [dbo].[AccountsLedger] (
    [BranchID]          VARCHAR (15)    NOT NULL,
    [LedgerID]          VARCHAR (10)    NOT NULL,
    [LedgerNameEnglish] VARCHAR (50)    NOT NULL,
    [LedgerNameArabic]  NVARCHAR (50)   NULL,
    [ParentID]          VARCHAR (10)    NOT NULL,
    [PrimaryGroupID]    VARCHAR (10)    NULL,
    [LedgerStatus]      BIT             NULL,
    [OpeningBalance]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [ClosingBalance]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [BalanceAmt]        NUMERIC (12, 2) DEFAULT (0) NULL,
    [CreditAmt]         NUMERIC (12, 2) DEFAULT (0) NULL,
    [DebitAmt]          NUMERIC (12, 2) DEFAULT (0) NULL,
    [ThisYearBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [PrevYearBalance]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [ThisQtrBalance]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [PrevQtrBalance]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [LedgerNature]      NUMERIC (1)     NULL,
    [CostCentres]       VARCHAR (15)    NULL,
    [Address]           NTEXT           NULL,
    [City]              VARCHAR (30)    NULL,
    [Phone_Mobile]      VARCHAR (40)    NULL,
    [ContactPerson]     NVARCHAR (40)   NULL,
    [eMail]             VARCHAR (30)    NULL,
    [Remark]            VARCHAR (300)   NULL,
    [UserID]            VARCHAR (15)    NULL,
    [Create_Date]       DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]         VARCHAR (20)    DEFAULT (host_name()) NULL,
    [primary_key]       INT             IDENTITY (1, 1) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AccountsLedger]
    ON [dbo].[AccountsLedger]([LedgerID] ASC, [ParentID] ASC);

