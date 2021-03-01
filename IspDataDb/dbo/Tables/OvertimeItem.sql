CREATE TABLE [dbo].[OvertimeItem] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NULL,
    [PayrollIdNo]     SMALLINT       NULL,
    [OvertimeRegular] DECIMAL (8, 4) NULL,
    [OvertimeHoliday] DECIMAL (8, 4) NULL,
    [OvertimeSpecial] DECIMAL (8, 4) NULL, 
    CONSTRAINT [PK_OvertimeItem] PRIMARY KEY ([IdNo])
);







