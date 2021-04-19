CREATE TABLE [dbo].[ArJournal] (
    [IDNo]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerIdNo]       INT            NOT NULL,
    [TransactionDate]    DATE           NULL,
    [ReferenceNo]        VARCHAR (15)   NULL,
    [TransactionType]    CHAR (1)       NULL,
    [Amount]             MONEY          NOT NULL,
    [AccountIdNo]        INT            NOT NULL,
    [DueDate]            DATE           NULL,
    [SettlementDueDate]  DATE           NULL,
    [SettlementDiscount] DECIMAL (5, 2) NULL,
    [InvoiceNo]          VARCHAR (15)   NOT NULL,
    [InvoiceDate]        DATE           NULL,
    [Notes]              NVARCHAR (300) NOT NULL,
    [VatAmount]          MONEY          NULL,
    [Posted]             BIT            NULL,
    [Cancelled]          BIT            NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_ArJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ArJournal] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);







