CREATE TABLE [dbo].[SalaryLoan] (
    [IdNo]          INT        NOT NULL,
    [EmployeeIdNo]  INT        NOT NULL,
    [Amount]        SMALLMONEY NULL,
    [StartDate]     DATE       NULL,
    [EndDate]       DATE       NULL,
    [DateTimeStamp] ROWVERSION NULL
);

