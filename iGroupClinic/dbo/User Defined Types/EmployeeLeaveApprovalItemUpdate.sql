CREATE TYPE [dbo].[EmployeeLeaveApprovalItemUpdate] AS TABLE (
    [ApprovalNote]              NVARCHAR (50) NULL,
    [EmployeeLeaveApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveIdNo]         INT           NOT NULL,
    [IdNo]                      INT           NOT NULL,
    [Status]                    CHAR (1)      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

