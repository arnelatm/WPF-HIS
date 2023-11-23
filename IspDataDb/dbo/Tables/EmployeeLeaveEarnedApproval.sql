CREATE TABLE [dbo].[EmployeeLeaveEarnedApproval] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [ApprovedBy]    INT        NULL,
    [DateCreated]   DATETIME   CONSTRAINT [DF_EmployeeLeaveEarnedStatus_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_EmployeeLeaveEarnedStatus] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

