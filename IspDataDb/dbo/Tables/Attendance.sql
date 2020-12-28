CREATE TABLE [dbo].[Attendance] (
    [IdNo]                 INT            NULL,
    [EmployeeIdNo]         INT            NULL,
    [PayPeriodIdNo]        SMALLINT       NULL,
    [DaysPresent]          DECIMAL (5, 2) NULL,
    [DaysAbsentWithPay]    DECIMAL (5, 2) NULL,
    [DaysAbsentWithoutPay] DECIMAL (5, 2) NULL,
    [DaysOff]              DECIMAL (5, 2) NULL
);

