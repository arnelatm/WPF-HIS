CREATE TYPE [dbo].[EmployeeLeaveEarnedApprovalItemInsert] AS TABLE (
    [ApprovalNote]                    NVARCHAR (50) NULL,
    [Approved]                        BIT           NOT NULL,
    [Disapproved]                     BIT           NOT NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveEarnedIdNo]         INT           NOT NULL);



