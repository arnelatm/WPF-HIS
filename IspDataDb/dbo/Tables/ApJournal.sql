CREATE TABLE [dbo].[ApJournal] (
    [IDNo]               INT            IDENTITY (1, 1) NOT NULL,
    [SupplierIdNo]       INT            NOT NULL,
    [TransactionDate]    DATE           NULL,
    [ReferenceNo]        VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TransactionType]    CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]             MONEY          NOT NULL,
    [AccountIdNo]        INT            NOT NULL,
    [DueDate]            DATE           NULL,
    [SettlementDueDate]  DATE           NULL,
    [SettlementDiscount] DECIMAL (5, 2) NULL,
    [InvoiceNo]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [InvoiceDate]        DATE           NULL,
    [VatNumber]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [VatAmount]          MONEY          NULL,
    [Notes]              NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]             BIT            NULL,
    [Cancelled]          BIT            NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_ApJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_ApIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);



