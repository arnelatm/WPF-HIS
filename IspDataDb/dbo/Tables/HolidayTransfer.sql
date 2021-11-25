CREATE TABLE [dbo].[HolidayTransfer] (
    [IdNo]          INT        NULL,
    [HolidayIdNo]   INT        NULL,
    [EmployeeIdNo]  INT        NULL,
    [AppliedBy]     INT        NULL,
    [DateCreated]   DATE       NULL,
    [DateTimeStamp] ROWVERSION NULL
);

