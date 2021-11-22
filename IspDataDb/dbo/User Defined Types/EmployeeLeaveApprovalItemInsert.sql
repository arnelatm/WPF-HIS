CREATE TYPE [dbo].[EmployeeLeaveApprovalItemInsert] AS TABLE (
    [EmployeeLeaveApprovalIdNo] INT           NOT NULL,
    [EmployeeLeaveIdNo]         INT           NOT NULL,
    [Note]                      NVARCHAR (50) NULL,
    [Status]                    CHAR (1)      NOT NULL);

