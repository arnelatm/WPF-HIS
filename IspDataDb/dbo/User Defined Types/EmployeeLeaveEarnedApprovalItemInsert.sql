CREATE TYPE [dbo].[EmployeeLeaveEarnedApprovalItemInsert] AS TABLE (
    [ApprovalNote]                    NVARCHAR (50) NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveEarnedIdNo]         INT           NOT NULL,
    [Status]                          CHAR (1)      NOT NULL);

