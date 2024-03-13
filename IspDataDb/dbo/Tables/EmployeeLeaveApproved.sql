CREATE TABLE [dbo].[EmployeeLeaveApproved] (
    [IdNo]                      INT      NULL,
    [EmployeeLeaveApprovalIdNo] INT      NULL,
    [EmployeeLeaveIdNo]         INT      IDENTITY (1, 1) NOT NULL,
    [Status]                    CHAR (1) NULL
);

