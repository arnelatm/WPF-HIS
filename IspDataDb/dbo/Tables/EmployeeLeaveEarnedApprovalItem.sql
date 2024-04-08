CREATE TABLE [dbo].[EmployeeLeaveEarnedApprovalItem] (
    [IdNo]                            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveEarnedApprovalIdNo] INT            NULL,
    [EmployeeLeaveEarnedIdNo]         INT            NULL,
    [Approved]                        BIT            NULL,
    [Disapproved]                     BIT            NULL,
    [ApprovalNote]                    NVARCHAR (100) NULL,
    CONSTRAINT [PK_EmployeeLeaveEarnedStatusItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



