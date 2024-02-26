CREATE TABLE [dbo].[EmployeeLeave] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT            NOT NULL,
    [LeaveIdNo]     SMALLINT       NOT NULL,
    [HolidayIdNo]   SMALLINT       NULL,
    [StartDate]     DATETIME       NOT NULL,
    [EndDate]       DATETIME       NOT NULL,
    [FullDay]       BIT            NULL,
    [EnteredBy]     INT            NOT NULL,
    [Reason]        NVARCHAR (200) NULL,
    [DateCreated]   DATETIME       CONSTRAINT [DF_EmployeeLeave_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



























