CREATE TABLE [dbo].[EmployeeLeaveApproved] (
    [IdNo]                      INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveApprovalIdNo] INT      NULL,
    [EmployeeLeaveIdNo]         INT      NOT NULL,
    [Status]                    CHAR (1) NULL,
    CONSTRAINT [PK_EmployeeLeaveApproved] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



