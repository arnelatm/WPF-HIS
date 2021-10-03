CREATE TABLE [dbo].[AttendanceItem] (
    [IdNo]                 INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]         INT             NULL,
    [PayrollIdNo]          SMALLINT        NULL,
    [DaysPresent]          DECIMAL (8, 4)  NULL,
    [DaysAbsentWithPay]    DECIMAL (8, 4)  NULL,
    [DaysAbsentWithoutPay] DECIMAL (8, 4)  NULL,
    [DaysVacationLeave]    DECIMAL (18, 4) NULL,
    [DaysOff]              DECIMAL (8, 4)  NULL,
    [Sequence]             SMALLINT        NULL,
    CONSTRAINT [PK_AttendanceItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











