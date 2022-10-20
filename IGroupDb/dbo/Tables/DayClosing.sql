CREATE TABLE [dbo].[DayClosing] (
    [BranchID]       VARCHAR (15)    NOT NULL,
    [ClosingDate]    VARCHAR (10)    NOT NULL,
    [CashAmount]     NUMERIC (12, 2) DEFAULT (0) NULL,
    [CreditAmount]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [OpeningAmount]  NUMERIC (12, 2) DEFAULT (0) NULL,
    [CashDiscount]   NUMERIC (12, 2) DEFAULT (0) NULL,
    [CreditDiscount] NUMERIC (12, 2) DEFAULT (0) NULL,
    [ClosingTime]    DATETIME        NULL,
    [UserID]         VARCHAR (15)    NULL,
    [MachineID]      VARCHAR (20)    NULL,
    [ClosingStatus]  VARCHAR (10)    DEFAULT ('Automatic') NULL,
    [ShiftClosed]    INT             DEFAULT (0) NULL,
    [VATAmt]         NUMERIC (10, 2) DEFAULT ((0)) NULL
);

