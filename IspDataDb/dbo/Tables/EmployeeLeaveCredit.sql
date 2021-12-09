CREATE TABLE [dbo].[EmployeeLeaveCredit] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]     INT            NULL,
    [LeaveIdNo]        SMALLINT       NOT NULL,
    [LeaveAllowed]     DECIMAL (6, 2) NULL,
    [PaidPercent]      DECIMAL (6, 2) NULL,
    [MaxCarryOver]     DECIMAL (6, 2) NULL,
    [Cumulative]       BIT            NULL,
    [MaxLimit]         DECIMAL (7, 2) NULL,
    [NoMaxLimit]       BIT            NULL,
    [AccumulatedLeave] DECIMAL (7, 2) NULL,
    [Sequence]         SMALLINT       NULL,
    [DateCreated]      DATETIME       CONSTRAINT [DF_EmployeeLeaveCredit_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeaveCreditIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







