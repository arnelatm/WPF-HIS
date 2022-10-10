CREATE TYPE [dbo].[OtWorkHourUpdate] AS TABLE (
    [EmployeeIdNo]    INT            NOT NULL,
    [HoursWorked]     INT            NULL,
    [IDNo]            INT            NOT NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NULL,
    [OvertimeRegular] DECIMAL (8, 4) NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NULL,
    [PayrollIdNo]     SMALLINT       NOT NULL,
    [Sequence]        SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

