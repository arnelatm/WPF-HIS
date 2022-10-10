CREATE TYPE [dbo].[EmployeeLeaveCreditInsert] AS TABLE (
    [AccumulatedLeave] DECIMAL (8, 2) NULL,
    [Cumulative]       BIT            NULL,
    [EmployeeIdNo]     INT            NOT NULL,
    [LeaveAllowed]     DECIMAL (6, 2) NULL,
    [LeaveIdNo]        SMALLINT       NOT NULL,
    [MaxCarryOver]     DECIMAL (6, 2) NULL,
    [MaxLimit]         DECIMAL (7, 2) NULL,
    [NoMaxLimit]       BIT            NULL,
    [PaidPercent]      DECIMAL (5, 2) NULL,
    [Sequence]         SMALLINT       NOT NULL);

