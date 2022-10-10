CREATE TYPE [dbo].[OtWorkHourInsert] AS TABLE (
    [EmployeeIdNo]    INT            NOT NULL,
    [HoursWorked]     DECIMAL (8, 4) NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NULL,
    [OvertimeRegular] DECIMAL (8, 4) NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NULL,
    [PayrollIdNo]     SMALLINT       NOT NULL,
    [Sequence]        SMALLINT       NULL);

