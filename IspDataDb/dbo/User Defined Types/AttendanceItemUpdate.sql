CREATE TYPE [dbo].[AttendanceItemUpdate] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (18) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (18) NOT NULL,
    [DaysOff]              DECIMAL (18) NOT NULL,
    [DaysPresent]          DECIMAL (18) NOT NULL,
    [EmployeeIdNo]         INT          NOT NULL,
    [IDNo]                 INT          NOT NULL,
    [PayPeriodIdNo]        SMALLINT     NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));



