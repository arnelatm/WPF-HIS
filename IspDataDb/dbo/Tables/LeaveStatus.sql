CREATE TABLE [dbo].[LeaveStatus] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveIdNo] INT            NULL,
    [EnteredBy]         INT            NULL,
    [Status]            CHAR (1)       NULL,
    [Note]              NVARCHAR (100) NULL,
    [DateAdded]         DATETIME       CONSTRAINT [DF_LeaveStatus_DateAdded] DEFAULT (getdate()) NULL,
    [DateTimeStamp]     ROWVERSION     NULL
);



