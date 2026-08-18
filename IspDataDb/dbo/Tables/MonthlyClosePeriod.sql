CREATE TABLE [dbo].[MonthlyClosePeriod] (
    [FiscalYear]       INT          NOT NULL,
    [FiscalMonth]      TINYINT      NOT NULL,
    [Status]            VARCHAR (20) NOT NULL CONSTRAINT [DF_MonthlyClosePeriod_Status] DEFAULT ('Open'),
    [ApprovedBy]        SYSNAME      NULL,
    [ApprovedAt]        DATETIME2 (0) NULL,
    [ClosedBy]          SYSNAME      NULL,
    [ClosedAt]          DATETIME2 (0) NULL,
    [ApprovalNotes]     NVARCHAR (500) NULL,
    CONSTRAINT [PK_MonthlyClosePeriod] PRIMARY KEY ([FiscalYear], [FiscalMonth]),
    CONSTRAINT [CK_MonthlyClosePeriod_Month] CHECK ([FiscalMonth] BETWEEN 1 AND 12),
    CONSTRAINT [CK_MonthlyClosePeriod_Status] CHECK ([Status] IN ('Open', 'Approved', 'Closed'))
);
