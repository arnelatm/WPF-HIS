CREATE TABLE [dbo].[PayrollEarnAccount] (
    [IdNo]         INT      IDENTITY (1, 1) NOT NULL,
    [EarningIdNo]  SMALLINT NULL,
    [PayGroupIdNo] SMALLINT NULL,
    [EmployeeIdNo] INT      NULL,
    [AccountIdNo]  SMALLINT NULL,
    [Sequence]     SMALLINT NULL,
    CONSTRAINT [PK_PayrollEarnAccount] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





