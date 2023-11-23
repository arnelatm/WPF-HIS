CREATE TYPE [dbo].[EmployeeLeaveEarnedApprovalItemUpdate] AS TABLE (
    [ApprovalNote]                    NVARCHAR (50) NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveEarnedIdNo]         INT           NOT NULL,
    [IdNo]                            INT           NOT NULL,
    [Status]                          CHAR (1)      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

