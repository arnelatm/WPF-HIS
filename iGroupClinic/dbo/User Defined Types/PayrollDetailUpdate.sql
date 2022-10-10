CREATE TYPE [dbo].[PayrollDetailUpdate] AS TABLE (
    [BankTransfer] BIT      NOT NULL,
    [EmployeeIdNo] INT      NOT NULL,
    [IdNo]         INT      NOT NULL,
    [PayrollIdNo]  SMALLINT NOT NULL);

