CREATE TABLE [dbo].[FiscalYearJournalPostingRun] (
    [IdNo]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [RunId]          UNIQUEIDENTIFIER NOT NULL,
    [FiscalYear]     INT              NOT NULL,
    [FiscalYearStart] DATE            NOT NULL,
    [FiscalYearEnd]   DATE            NOT NULL,
    [Status]          VARCHAR (20)     NOT NULL,
    [StartedAt]       DATETIME2 (0)    NOT NULL,
    [CompletedAt]     DATETIME2 (0)    NULL,
    [ExecutedBy]      SYSNAME          NOT NULL,
    [ServerName]      NVARCHAR (128)   NOT NULL,
    [DatabaseName]    SYSNAME          NOT NULL,
    [HeadersChanged]  INT              NOT NULL,
    [ItemsChanged]    INT              NOT NULL,
    CONSTRAINT [PK_FiscalYearJournalPostingRun] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_FiscalYearJournalPostingRun_RunId] UNIQUE NONCLUSTERED ([RunId] ASC),
    CONSTRAINT [CK_FiscalYearJournalPostingRun_Status]
        CHECK ([Status] IN ('Completed', 'Reversed')),
    CONSTRAINT [CK_FiscalYearJournalPostingRun_Dates]
        CHECK ([FiscalYearStart] <= [FiscalYearEnd])
);
