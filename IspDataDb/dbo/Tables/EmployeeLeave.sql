CREATE TABLE [dbo].[EmployeeLeave] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT            NULL,
    [LeaveIdNo]     SMALLINT       NOT NULL,
    [LeaveStart]    DATETIME       NULL,
    [LeaveEnd]      DATETIME       NULL,
    [FullDayLeave]  BIT            NULL,
    [LeaveStatus]   CHAR (1)       NULL,
    [LeaveReason]   NVARCHAR (200) NULL,
    [DateCreated]   NCHAR (10)     NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







