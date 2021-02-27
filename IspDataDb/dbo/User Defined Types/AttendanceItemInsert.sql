CREATE TYPE [dbo].[AttendanceItemInsert] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (8, 4) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4) NOT NULL,
    [DaysOff]              DECIMAL (8, 4) NOT NULL,
    [DaysPresent]          DECIMAL (8, 4) NOT NULL,
    [EmployeeIdNo]         INT            NOT NULL,
    [Overtime1]            DECIMAL (8, 2) NOT NULL,
    [Overtime2]            DECIMAL (8, 2) NOT NULL,
    [PayrollIdNo]          SMALLINT       NOT NULL);





