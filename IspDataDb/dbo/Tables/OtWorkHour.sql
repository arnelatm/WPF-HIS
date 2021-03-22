CREATE TABLE [dbo].[OTWorkHour] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NULL,
    [PayrollIdNo]     SMALLINT       NULL,
    [HoursWorked]     DECIMAL (8, 4) NULL,
    [OvertimeRegular] DECIMAL (8, 4) NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NULL,
    [Sequence]        SMALLINT       NULL,
    CONSTRAINT [PK_OtWorkHour] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











