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
    [Notes] NVARCHAR (300) NOT NULL
);
