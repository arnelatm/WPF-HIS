CREATE TABLE [dbo].[EmployeeLeave] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT            NULL,
    [LeaveIdNo]     SMALLINT       NOT NULL,
    [StartDate]     DATETIME       NULL,
    [EndDate]       DATETIME       NULL,
    [FullDay]       BIT            NULL,
    [LeaveStatus]   CHAR (1)       NULL,
    [LeaveReason]   NVARCHAR (200) NULL,
    [Sequence]      INT            NULL,
    [DateCreated]   DATETIME       CONSTRAINT [DF_EmployeeLeave_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);













