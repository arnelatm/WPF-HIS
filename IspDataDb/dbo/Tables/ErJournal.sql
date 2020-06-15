CREATE TABLE [dbo].[ErJournal] (
    [IDNo]               INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]       INT            NOT NULL,
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
    [Notes]              NVARCHAR (255) NOT NULL,
    [Posted]             BIT            NULL,
    [Cancelled]          BIT            NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_ErJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ErIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);

