CREATE TABLE [dbo].[EmployeeLeaveCredit] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]     INT            NULL,
    [LeaveIdNo]        SMALLINT       NOT NULL,
    [LeaveAllowed]     SMALLINT       NULL,
    [PaidPercent]      DECIMAL (5, 2) NULL,
    [MaxCarryOver]     SMALLINT       NULL,
    [Cumulative]       BIT            NULL,
    [MaxLimit]         SMALLINT       NULL,
    [NoMaxLimit]       BIT            NULL,
    [AccumulatedLeave] DECIMAL (8, 2) NULL,
    [DateCreated]      DATETIME       CONSTRAINT [DF_EmployeeLeaveCredit_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeaveCreditIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

