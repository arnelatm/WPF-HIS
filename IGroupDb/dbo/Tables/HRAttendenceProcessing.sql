CREATE TABLE [dbo].[HRAttendenceProcessing] (
    [BranchID]     VARCHAR (15) NOT NULL,
    [Serial_No]    NUMERIC (10) NOT NULL,
    [AttendenceID] VARCHAR (15) NOT NULL,
    [Date]         VARCHAR (10) NOT NULL,
    [LoginTime]    DATETIME     NULL,
    [Status]       INT          NULL,
    [Countable]    INT          NULL
);

