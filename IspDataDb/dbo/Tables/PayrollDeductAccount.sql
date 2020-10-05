CREATE TABLE [dbo].[PayrollDeductAccount] (
    [IdNo]          INT      IDENTITY (1, 1) NOT NULL,
    [DeductionIdNo] SMALLINT NULL,
    [PayGroupIdNo]  SMALLINT NULL,
    [EmployeeIdNo]  INT      NULL,
    [AccountIdNo]   SMALLINT NULL,
    [Sequence]      SMALLINT NULL,
    CONSTRAINT [PK_PayrollDeductAccount] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

