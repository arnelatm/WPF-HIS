CREATE TABLE [dbo].[EmployeeLeaveStatus] (
    [IdNo]              INT            NULL,
    [EmployeeLeaveIdNo] INT            NULL,
    [EnteredBy]         INT            NULL,
    [Status]            CHAR (1)       NULL,
    [Note]              NVARCHAR (100) NULL,
    [DateCreated]       DATETIME       NULL,
    [DateTimeStamp]     ROWVERSION     NULL
);

