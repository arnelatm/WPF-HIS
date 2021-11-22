CREATE TABLE [dbo].[EmployeeLeaveApproval] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [EnteredBy]     INT        NULL,
    [DateCreated]   DATETIME   CONSTRAINT [DF_EmployeeLeaveStatus_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_EmployeeLeaveStatus] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





