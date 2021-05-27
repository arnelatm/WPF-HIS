CREATE TABLE [dbo].[SalaryLoanSchedule] (
    [IdNo]            INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT        NULL,
    [Amount]          SMALLMONEY NULL,
    [StartDate]       DATE       NULL,
    [PeriodicPayment] SMALLMONEY NULL,
    [DateCreated]     DATETIME   CONSTRAINT [DF_SalaryLoanSchedule_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION NULL,
    CONSTRAINT [PK_SalaryLoan] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



