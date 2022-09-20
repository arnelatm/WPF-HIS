CREATE TABLE [dbo].[HRVacationContract] (
    [BranchID]            VARCHAR (15)    NULL,
    [EmpID]               VARCHAR (15)    NULL,
    [VacationDaysPerYear] NUMERIC (5)     NULL,
    [NoOfTimesPerYear]    NUMERIC (1)     NULL,
    [WithSalary]          INT             NULL,
    [WithFare]            INT             NULL,
    [ExtraVacationSalary] NUMERIC (10, 2) NULL
);

