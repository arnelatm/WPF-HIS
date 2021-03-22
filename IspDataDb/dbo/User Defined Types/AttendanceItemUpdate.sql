CREATE TYPE [dbo].[AttendanceItemUpdate] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (8, 4) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4) NOT NULL,
    [DaysOff]              DECIMAL (8, 4) NOT NULL,
    [DaysPresent]          DECIMAL (8, 4) NOT NULL,
    [EmployeeIdNo]         INT            NOT NULL,
    [IDNo]                 INT            NOT NULL,
    [PayrollIdNo]          SMALLINT       NOT NULL,
    [Sequence]             SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));







