CREATE TABLE [dbo].[PayrollGeneralJournal] (
    [PayrollIdNo]       SMALLINT NOT NULL,
    [GeneralJournalIdNo] INT     NOT NULL,
    [DateCreated]       DATETIME NOT NULL CONSTRAINT [DF_PayrollGeneralJournal_DateCreated] DEFAULT (GETDATE()),
    CONSTRAINT [PK_PayrollGeneralJournal] PRIMARY KEY CLUSTERED ([PayrollIdNo] ASC),
    CONSTRAINT [UQ_PayrollGeneralJournal_GeneralJournalIdNo] UNIQUE NONCLUSTERED ([GeneralJournalIdNo] ASC),
    CONSTRAINT [FK_PayrollGeneralJournal_Payroll] FOREIGN KEY ([PayrollIdNo]) REFERENCES [dbo].[Payroll] ([IdNo]),
    CONSTRAINT [FK_PayrollGeneralJournal_GeneralJournal] FOREIGN KEY ([GeneralJournalIdNo]) REFERENCES [dbo].[GeneralJournal] ([IdNo]) ON DELETE CASCADE
);
GO
