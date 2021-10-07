CREATE TYPE [dbo].[EmployeeLeaveCreditUpdate] AS TABLE (
    [AccumulatedLeave] DECIMAL (8, 2) NULL,
    [Cumulative]       BIT            NOT NULL,
    [EmployeeIdNo]     INT            NOT NULL,
    [IdNo]             INT            NOT NULL,
    [LeaveAllowed]     DECIMAL (6, 2) NULL,
    [LeaveIdNo]        SMALLINT       NOT NULL,
    [MaxCarryOver]     DECIMAL (6, 2) NULL,
    [MaxLimit]         DECIMAL (7, 2) NULL,
    [PaidPercent]      DECIMAL (5, 2) NOT NULL,
    [Sequence]         SMALLINT       NOT NULL);

