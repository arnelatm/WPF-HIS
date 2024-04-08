CREATE TYPE [dbo].[EmployeeLeaveEarnedApprovalItemUpdate] AS TABLE (
    [ApprovalNote]                    NVARCHAR (50) NULL,
    [Approved]                        BIT           NOT NULL,
    [Disapproved]                     BIT           NOT NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveEarnedIdNo]         INT           NOT NULL,
    [IdNo]                            INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));



