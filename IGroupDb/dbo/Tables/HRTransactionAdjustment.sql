CREATE TABLE [dbo].[HRTransactionAdjustment] (
    [BranchID]    VARCHAR (15)    NULL,
    [TransNo]     NUMERIC (10)    NOT NULL,
    [TransDate]   VARCHAR (10)    NULL,
    [EmpID]       VARCHAR (15)    NOT NULL,
    [PeriodMonth] VARCHAR (30)    NOT NULL,
    [PeriodYear]  VARCHAR (10)    NOT NULL,
    [RowNbr]      NUMERIC (5)     NULL,
    [TransID]     VARCHAR (15)    NOT NULL,
    [Amount]      NUMERIC (10, 2) NULL,
    [Remarks]     VARCHAR (100)   NULL
);

