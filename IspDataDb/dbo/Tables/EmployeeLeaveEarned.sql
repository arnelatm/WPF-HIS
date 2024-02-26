CREATE TABLE [dbo].[EmployeeLeaveEarned] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT            NOT NULL,
    [LeaveIdNo]     SMALLINT       NOT NULL,
    [StartDate]     DATE           CONSTRAINT [DF_EmployeeLeaveEarned_StartDate] DEFAULT (getdate()) NOT NULL,
    [EndDate]       DATE           CONSTRAINT [DF_EmployeeLeaveEarned_EndDate] DEFAULT (getdate()) NOT NULL,
    [Reason]        VARCHAR (50)   NOT NULL,
    [DaysEarned]    DECIMAL (9, 4) CONSTRAINT [DF_EmployeeLeaveEarned_DaysEarned] DEFAULT ((0)) NOT NULL,
    [EnteredBy]     INT            NOT NULL,
    [Posted]        BIT            CONSTRAINT [DF_EmployeeLeaveEarned_Posted] DEFAULT ((0)) NOT NULL,
    [DateCreated]   DATE           CONSTRAINT [DF_EmployeeLeaveEarned_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_EmployeeLeaveEarned] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









