CREATE TABLE [dbo].[EmployeeLeaveEarnedApprovalItem] (
    [IdNo]                            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT            NULL,
    [EmployeeLeaveEarnedIdNo]         INT            NULL,
    [Status]                          CHAR (1)       NULL,
    [ApprovalNote]                    NVARCHAR (100) NULL,
    CONSTRAINT [PK_EmployeeLeaveEarnedStatusItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

