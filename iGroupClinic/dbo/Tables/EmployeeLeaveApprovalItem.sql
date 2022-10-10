CREATE TABLE [dbo].[EmployeeLeaveApprovalItem] (
    [IdNo]                      INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveApprovalIdNo] INT            NULL,
    [EmployeeLeaveIdNo]         INT            NULL,
    [Status]                    CHAR (1)       NULL,
    [ApprovalNote]              NVARCHAR (100) NULL,
    CONSTRAINT [PK_EmployeeLeaveStatusItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

