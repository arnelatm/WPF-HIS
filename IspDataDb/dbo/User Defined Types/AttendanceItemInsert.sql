CREATE TYPE [dbo].[AttendanceItemInsert] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (18) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (18) NOT NULL,
    [DaysOff]              DECIMAL (18) NOT NULL,
    [DaysPresent]          DECIMAL (18) NOT NULL,
    [EmployeeIdNo]         INT          NOT NULL,
    [PayPeriodIdNo]        SMALLINT     NOT NULL,
    [Sequence]             INT          NOT NULL);

