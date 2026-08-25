CREATE TABLE [dbo].[MonthlyClosePeriod] (
    [FiscalYear]       INT          NOT NULL,
    [FiscalMonth]      TINYINT      NOT NULL,
    [Status]            VARCHAR (20) NOT NULL CONSTRAINT [DF_MonthlyClosePeriod_Status] DEFAULT ('Open'),
    [ApprovedBy]        SYSNAME      NULL,
    [ApprovedAt]        DATETIME2 (0) NULL,
    [ClosedBy]          SYSNAME      NULL,
    [ClosedAt]          DATETIME2 (0) NULL,
    [ApprovalNotes]     NVARCHAR (1000) NULL,
    CONSTRAINT [PK_MonthlyClosePeriod] PRIMARY KEY ([FiscalYear], [FiscalMonth]),
    CONSTRAINT [CK_MonthlyClosePeriod_Month] CHECK ([FiscalMonth] >= (1) AND [FiscalMonth] <= (12)),
    CONSTRAINT [CK_MonthlyClosePeriod_Status] CHECK ([Status] = 'Closed' OR [Status] = 'Approved' OR [Status] = 'Open')
);
