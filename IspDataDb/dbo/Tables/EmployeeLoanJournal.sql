CREATE TABLE [dbo].[EmployeeLoanJournal] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NOT NULL,
    [TransactionDate] DATE           NULL,
    [ReferenceNo]     VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TransactionType] CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]          MONEY          NOT NULL,
    [AccountIdNo]     SMALLINT       NOT NULL,
    [Notes]           NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Posted]          BIT            NULL,
    [Cancelled]       BIT            NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_EmployeeLoanJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK_EmployeeLoanIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





