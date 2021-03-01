CREATE TYPE [dbo].[OvertimeItemInsert] AS TABLE (
    [EmployeeIdNo]    INT            NOT NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NOT NULL,
    [OvertimeRegular] DECIMAL (8, 4) NOT NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NOT NULL,
    [PayrollIdNo]     SMALLINT       NOT NULL);





