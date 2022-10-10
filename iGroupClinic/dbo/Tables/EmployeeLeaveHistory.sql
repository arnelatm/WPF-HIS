CREATE TABLE [dbo].[EmployeeLeaveHistory] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]      INT            NULL,
    [LeaveIdNo]         SMALLINT       NULL,
    [NumberOfDays]      DECIMAL (7, 2) NULL,
    [LeaveType]         CHAR (1)       NULL,
    [TransactontDate]   DATE           NULL,
    [EmployeeLeaveIdNo] INT            NULL,
    CONSTRAINT [PK_EmployeeLeaveHistory] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

