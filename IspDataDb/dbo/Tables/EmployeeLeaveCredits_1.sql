CREATE TABLE [dbo].[EmployeeLeaveCredits] (
    [IdNo]              SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]      INT            NOT NULL,
    [LeaveIdNo]         SMALLINT       NOT NULL,
    [LeaveAllowed]      SMALLINT       NULL,
    [PaidPercent]       DECIMAL (5, 2) NULL,
    [MaxCarryOver]      SMALLINT       NULL,
    [Cumulative]        BIT            NULL,
    [MaxLimit]          SMALLINT       NULL,
    [NoMaxLimit]        BIT            NULL,
    [AccumulatedLeaves] INT            NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeLeaveCredits] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

