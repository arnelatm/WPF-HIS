CREATE TABLE [dbo].[HREmployeeDuty] (
    [BranchID]        VARCHAR (15)   NULL,
    [TransDate]       VARCHAR (10)   NOT NULL,
    [ShiftID]         VARCHAR (15)   NOT NULL,
    [EmpID]           VARCHAR (15)   NOT NULL,
    [DepartmentID]    VARCHAR (15)   NULL,
    [DutyHrs]         NUMERIC (2)    NULL,
    [TimeIn1]         VARCHAR (25)   NULL,
    [TimeOut1]        VARCHAR (25)   NULL,
    [TimeIn2]         VARCHAR (25)   NULL,
    [TimeOut2]        VARCHAR (25)   NULL,
    [Status]          INT            NULL,
    [DutyHrsDone]     NUMERIC (5, 2) NULL,
    [LateOTTime]      NUMERIC (3)    NULL,
    [MarketingPerson] INT            NULL,
    [PunchRequred]    INT            NULL,
    [OffDay]          INT            NULL,
    [OnLeave]         INT            NULL,
    [LeaveType]       VARCHAR (15)   NULL,
    [LogIndex]        NUMERIC (10)   NULL,
    [Authanticate]    INT            NULL,
    [AuthReason]      VARCHAR (30)   NULL
);

