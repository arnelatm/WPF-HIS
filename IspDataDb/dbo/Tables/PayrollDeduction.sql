CREATE TABLE [dbo].[PayrollDeduction] (
    [IdNo]          INT   IDENTITY (1, 1) NOT NULL,
    [PayrollIdNo]   INT   NULL,
    [EmployeeIdNo]  INT   NULL,
    [DeductionIdNo] INT   NULL,
    [Amount]        MONEY NULL,
    CONSTRAINT [PK_PayrollDeduction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





