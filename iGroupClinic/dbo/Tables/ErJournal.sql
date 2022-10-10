CREATE TABLE [dbo].[ErJournal] (
    [IDNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NOT NULL,
    [TransactionDate] DATE           NULL,
    [ReferenceNo]     VARCHAR (15)   NULL,
    [TransactionType] CHAR (1)       NULL,
    [Amount]          MONEY          NOT NULL,
    [AccountIdNo]     SMALLINT       NOT NULL,
    [Notes]           NVARCHAR (255) NOT NULL,
    [Posted]          BIT            NULL,
    [Approved]        BIT            NULL,
    [Cancelled]       BIT            NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_ErJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ErIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);

