CREATE TABLE [dbo].[KizenPharmacyJournalImport]
(
    [SourcePeriodStart] DATE NOT NULL,
    [SourcePeriodEnd] DATE NOT NULL,
    [GeneralJournalIdNo] INT NOT NULL,
    [ReceiptCount] INT NOT NULL,
    [InvoiceCount] INT NOT NULL,
    [ZeroRated] MONEY NOT NULL,
    [WithVat] MONEY NOT NULL,
    [DateCreated] DATETIME NOT NULL CONSTRAINT [DF_KizenPharmacyJournalImport_DateCreated] DEFAULT (GETDATE()),
    CONSTRAINT [PK_KizenPharmacyJournalImport] PRIMARY KEY CLUSTERED ([SourcePeriodStart]),
    CONSTRAINT [FK_KizenPharmacyJournalImport_GeneralJournal] FOREIGN KEY ([GeneralJournalIdNo]) REFERENCES [dbo].[GeneralJournal] ([IdNo])
);
GO
