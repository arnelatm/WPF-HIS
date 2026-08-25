CREATE TABLE [dbo].[MonthlyCloseChecklist] (
    [FiscalYear]       INT           NOT NULL,
    [FiscalMonth]      TINYINT       NOT NULL,
    [ChecklistCode]    VARCHAR (40)   NOT NULL,
    [Completed]        BIT           NOT NULL CONSTRAINT [DF_MonthlyCloseChecklist_Completed] DEFAULT (0),
    [CompletedBy]      SYSNAME       NULL,
    [CompletedAt]      DATETIME2 (0) NULL,
    [Notes]            NVARCHAR (1000) NULL,
    CONSTRAINT [PK_MonthlyCloseChecklist] PRIMARY KEY ([FiscalYear], [FiscalMonth], [ChecklistCode]),
    CONSTRAINT [CK_MonthlyCloseChecklist_Month] CHECK ([FiscalMonth] >= (1) AND [FiscalMonth] <= (12))
);
