CREATE TABLE [dbo].[KizenRevenueJournalImport]
(
    [SourcePeriodStart] DATE NOT NULL,
    [SourcePeriodEnd] DATE NOT NULL,
    [GeneralJournalIdNo] INT NOT NULL,
    [ReceiptCount] INT NOT NULL,
    [InvoiceCount] INT NOT NULL,
    [Taxable] MONEY NOT NULL,
    [Exempt] MONEY NOT NULL,
    [ZeroRated] MONEY NOT NULL,
    [Vat] MONEY NOT NULL,
    [WithVat] MONEY NOT NULL,
    [DateCreated] DATETIME NOT NULL CONSTRAINT [DF_KizenRevenueJournalImport_DateCreated] DEFAULT (GETDATE()),
    CONSTRAINT [PK_KizenRevenueJournalImport] PRIMARY KEY CLUSTERED ([SourcePeriodStart]),
    CONSTRAINT [FK_KizenRevenueJournalImport_GeneralJournal] FOREIGN KEY ([GeneralJournalIdNo]) REFERENCES [dbo].[GeneralJournal] ([IdNo])
);
GO
