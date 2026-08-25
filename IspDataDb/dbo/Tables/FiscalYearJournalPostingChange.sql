CREATE TABLE [dbo].[FiscalYearJournalPostingChange] (
    [IdNo]             BIGINT           IDENTITY (1, 1) NOT NULL,
    [RunId]            UNIQUEIDENTIFIER NOT NULL,
    [JournalCode]      CHAR (2)         COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RecordType]       CHAR (1)         NOT NULL,
    [RecordIdNo]       INT              NOT NULL,
    [JournalIdNo]      INT              NOT NULL,
    [PreviousPosted]   BIT              NULL,
    [NewPosted]        BIT              NOT NULL,
    CONSTRAINT [PK_FiscalYearJournalPostingChange] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_FiscalYearJournalPostingChange_Run]
        FOREIGN KEY ([RunId]) REFERENCES [dbo].[FiscalYearJournalPostingRun] ([RunId]),
    CONSTRAINT [UQ_FiscalYearJournalPostingChange_Record]
        UNIQUE NONCLUSTERED ([RunId] ASC, [JournalCode] ASC, [RecordType] ASC, [RecordIdNo] ASC),
    CONSTRAINT [CK_FiscalYearJournalPostingChange_RecordType]
        CHECK ([RecordType] = 'H' OR [RecordType] = 'I'),
    CONSTRAINT [CK_FiscalYearJournalPostingChange_NewPosted]
        CHECK ([NewPosted] = 1)
);
