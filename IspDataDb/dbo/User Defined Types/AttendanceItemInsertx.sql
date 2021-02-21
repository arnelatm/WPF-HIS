CREATE TYPE [dbo].[AttendanceItemInsertx] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (8, 4) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4) NOT NULL,
    [DaysOff]              DECIMAL (8, 4) NOT NULL,
    [DaysPresent]          DECIMAL (8, 4) NOT NULL,
    [EmployeeIdNo]         INT            NOT NULL,
    [Overtime]             DECIMAL (8, 2) NOT NULL,
    [PayPeriodIdNo]        SMALLINT       NOT NULL);

