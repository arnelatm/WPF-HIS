CREATE TYPE [dbo].[OtWorkHourUpdate] AS TABLE (
    [EmployeeIdNo]    INT            NOT NULL,
    [HoursWork]       INT            NULL,
    [IDNo]            INT            NOT NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NULL,
    [OvertimeRegular] DECIMAL (8, 4) NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NULL,
    [PayrollIdNo]     SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));





