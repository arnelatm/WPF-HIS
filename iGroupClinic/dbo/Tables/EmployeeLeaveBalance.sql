CREATE TABLE [dbo].[EmployeeLeaveBalance] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NULL,
    [LeaveIdNo]       SMALLINT       NOT NULL,
    [LeaveCreditIdNo] INT            NULL,
    [LeaveAllowed]    DECIMAL (6, 2) NULL,
    [LeaveBalance]    DECIMAL (6, 2) NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_EmployeeLeaveBalance_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeaveBalanceIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

