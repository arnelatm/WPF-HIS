CREATE TABLE [dbo].[PurchaseExpenses] (
    [BranchID]    VARCHAR (15)    NOT NULL,
    [Group_Key]   NUMERIC (10)    NOT NULL,
    [SlNo]        NUMERIC (3)     NOT NULL,
    [ExpenseHead] VARCHAR (5)     NULL,
    [Amount]      NUMERIC (12, 2) NULL,
    [TransDate]   VARCHAR (10)    NULL,
    [Refrence]    VARCHAR (20)    NULL,
    [Description] VARCHAR (50)    NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PurchaseExpenses]
    ON [dbo].[PurchaseExpenses]([BranchID] ASC, [Group_Key] ASC, [SlNo] ASC);

