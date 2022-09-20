CREATE TABLE [dbo].[AccountsOpeningBalance] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Period]      VARCHAR (6)     NOT NULL,
    [FinYear]     VARCHAR (4)     NULL,
    [TransNBR]    NUMERIC (10)    NOT NULL,
    [TransDate]   VARCHAR (10)    NOT NULL,
    [LedgerID]    VARCHAR (20)    NOT NULL,
    [Amount]      NUMERIC (12, 2) NULL,
    [CreditDebit] CHAR (1)        NULL,
    [BalanceType] CHAR (1)        NULL,
    [Remark]      VARCHAR (500)   NULL,
    [UserID]      VARCHAR (5)     NOT NULL,
    [Create_Date] DATETIME        NULL,
    [MachineID]   VARCHAR (20)    NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AccountsOpeningBalance]
    ON [dbo].[AccountsOpeningBalance]([BranchID] ASC, [FinYear] ASC, [Period] ASC, [LedgerID] ASC);

