CREATE TABLE [dbo].[RecurringPayElement] (
    [IdNo]            INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT        NULL,
    [Amount]          MONEY      NULL,
    [StartDate]       DATE       NULL,
    [PayElementIdNo]  SMALLINT   NULL,
    [PeriodicPayment] MONEY      NULL,
    [DateCreated]     DATETIME   CONSTRAINT [DF_SalaryLoanSchedule_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION NULL,
    CONSTRAINT [PK_SalaryLoan] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

