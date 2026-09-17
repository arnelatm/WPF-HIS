CREATE TYPE [dbo].[KizenArJournalHeaderInsert] AS TABLE
(
    [BatchSequence] INT NOT NULL,
    [CustomerIdNo] INT NOT NULL,
    [AccountIdNo] INT NOT NULL,
    [DueDate] DATE NULL,
    [Amount] MONEY NOT NULL,
    [VatAmount] MONEY NULL,
    [InvoiceNo] VARCHAR (15) NOT NULL,
    [InvoiceDate] DATE NULL,
    [Notes] NVARCHAR (300) NOT NULL,
    [InsuranceInvoiceID] INT NOT NULL,
    [CompanyCode] NVARCHAR (100) NOT NULL,
    [SupplyPeriodStart] DATE NOT NULL,
    [SupplyPeriodEnd] DATE NOT NULL,
    [SourceInvoiceCount] INT NOT NULL,
    [SourceDetailCount] INT NOT NULL,
    [TransactionDate] DATE NOT NULL
);
