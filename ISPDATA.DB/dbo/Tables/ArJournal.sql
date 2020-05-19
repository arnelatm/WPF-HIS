CREATE TABLE [dbo].[ArJournal] (
    [IDNo]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerIdNo]       INT            NOT NULL,
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
    [Notes]              NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]             BIT            NULL,
    [Cancelled]          BIT            NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_ArJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ArIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);

