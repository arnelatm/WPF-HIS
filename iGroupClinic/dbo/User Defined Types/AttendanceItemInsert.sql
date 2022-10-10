CREATE TYPE [dbo].[AttendanceItemInsert] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (8, 4) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4) NOT NULL,
    [DaysOff]              DECIMAL (8, 4) NOT NULL,
    [DaysPresent]          DECIMAL (8, 4) NOT NULL,
    [DaysTotal]            DECIMAL (8, 4) NOT NULL,
    [DaysVacationLeave]    DECIMAL (8, 4) NOT NULL,
    [EmployeeIdNo]         INT            NOT NULL,
    [PayrollIdNo]          SMALLINT       NOT NULL,
    [Sequence]             SMALLINT       NULL);

