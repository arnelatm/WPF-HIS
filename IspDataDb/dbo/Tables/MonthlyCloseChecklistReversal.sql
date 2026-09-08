CREATE TABLE [dbo].[MonthlyCloseChecklistReversal] (
    [IdNo]                    BIGINT          IDENTITY (1, 1) NOT NULL,
    [FiscalYear]              INT             NOT NULL,
    [FiscalMonth]             TINYINT         NOT NULL,
    [ChecklistCode]           VARCHAR (40)    NOT NULL,
    [PreviousCompletedBy]     SYSNAME         NULL,
    [PreviousCompletedAt]     DATETIME2 (0)   NULL,
    [PreviousNotes]           NVARCHAR (1000) NULL,
    [PreviousPeriodStatus]    VARCHAR (20)    NOT NULL,
    [PreviousApprovedBy]      SYSNAME         NULL,
    [PreviousApprovedAt]      DATETIME2 (0)   NULL,
    [PreviousApprovalNotes]   NVARCHAR (1000) NULL,
    [ReversalReason]          NVARCHAR (500)  NOT NULL,
    [ReversedBy]              SYSNAME         NOT NULL,
    [ReversedAt]              DATETIME2 (0)   NOT NULL,
    CONSTRAINT [PK_MonthlyCloseChecklistReversal] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [CK_MonthlyCloseChecklistReversal_Month] CHECK ([FiscalMonth] >= (1) AND [FiscalMonth] <= (12)),
    CONSTRAINT [CK_MonthlyCloseChecklistReversal_Status] CHECK ([PreviousPeriodStatus] = 'Approved' OR [PreviousPeriodStatus] = 'Open')
);
