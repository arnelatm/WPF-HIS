CREATE TABLE [dbo].[HREmployeeShiftDetails] (
    [EmpID]                       VARCHAR (15) NOT NULL,
    [ShiftID]                     VARCHAR (15) NOT NULL,
    [PunchNecessary]              INT          NULL,
    [PunchExceptionShiftStarting] NUMERIC (2)  NULL,
    [PunchExceptionShiftEnding]   NUMERIC (2)  NULL,
    [PunchExceptionRestStarting]  NUMERIC (2)  NULL,
    [PunchExceptionRestEnding]    NUMERIC (2)  NULL
);

