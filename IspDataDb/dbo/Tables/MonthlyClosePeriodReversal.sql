CREATE TABLE [dbo].[MonthlyClosePeriodReversal] (
    [IdNo]                  BIGINT        IDENTITY (1, 1) NOT NULL,
    [FiscalYear]            INT           NOT NULL,
    [FiscalMonth]           TINYINT       NOT NULL,
    [PreviousClosedThrough] DATE          NOT NULL,
    [NewClosedThrough]      DATE          NOT NULL,
    [ReopenedBy]            SYSNAME       NOT NULL,
    [ReopenedAt]            DATETIME2 (0) NOT NULL,
    CONSTRAINT [PK_MonthlyClosePeriodReversal] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [CK_MonthlyClosePeriodReversal_Month] CHECK ([FiscalMonth] >= (1) AND [FiscalMonth] <= (12)),
    CONSTRAINT [CK_MonthlyClosePeriodReversal_Dates] CHECK ([NewClosedThrough] < [PreviousClosedThrough])
);
