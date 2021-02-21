CREATE TYPE [dbo].[AttendanceItemUpdatex] AS TABLE (
    [DaysAbsentWithoutPay] DECIMAL (8, 4) NOT NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4) NOT NULL,
    [DaysOff]              DECIMAL (8, 4) NOT NULL,
    [DaysPresent]          DECIMAL (8, 4) NOT NULL,
    [EmployeeIdNo]         INT            NOT NULL,
    [IDNo]                 INT            NOT NULL,
    [Overtime]             DECIMAL (8, 2) NOT NULL,
    [PayPeriodIdNo]        SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

