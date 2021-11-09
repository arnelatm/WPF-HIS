CREATE TABLE [dbo].[EmployeeLeaveStatus] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeLeaveIdNo] INT            NULL,
    [EnteredBy]         INT            NULL,
    [Status]            CHAR (1)       NULL,
    [Note]              NVARCHAR (100) NULL,
    [DateCreated]       DATETIME       CONSTRAINT [DF_EmployeeLeaveStatus_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeaveStatus] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



