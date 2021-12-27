CREATE TYPE [dbo].[EmployeeLeaveApprovalItemInsert] AS TABLE (
    [ApprovalNote]              NVARCHAR (50) NULL,
    [EmployeeLeaveApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveIdNo]         INT           NOT NULL,
    [Status]                    CHAR (1)      NOT NULL);



