CREATE TABLE [dbo].[AccountsPeriodClose] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Period]      VARCHAR (6)     NOT NULL,
    [FinYear]     VARCHAR (4)     NULL,
    [YearClosed]  CHAR (1)        NULL,
    [ClosedDate]  VARCHAR (10)    NOT NULL,
    [CreditAmt]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [DebitAmt]    NUMERIC (12, 2) DEFAULT (0) NULL,
    [Remark]      VARCHAR (500)   NULL,
    [UserID]      VARCHAR (5)     NOT NULL,
    [Create_Date] DATETIME        NULL,
    [MachineID]   VARCHAR (20)    NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_AccountsPeriodClose]
    ON [dbo].[AccountsPeriodClose]([BranchID] ASC, [FinYear] ASC, [Period] ASC);

