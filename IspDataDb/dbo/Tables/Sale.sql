CREATE TABLE [dbo].[Sale] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]      INT            NULL,
    [PatientIdNo]     INT            NULL,
    [CustomerIdNo]    INT            NULL,
    [TransactionDate] DATE           NULL,
    [Cash]            BIT            NULL,
    [Amount]          DECIMAL (9, 2) NOT NULL,
    [DueDate]         DATE           NULL,
    [InvoiceNo]       VARCHAR (10)   NULL,
    [VatAmount]       DECIMAL (9, 2) NULL,
    [WarehouseIdNo]   SMALLINT       NULL,
    [JournalIdNo]     INT            NULL,
    [Posted]          BIT            NULL,
    [Cancelled]       BIT            NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_SalesDateCreated] DEFAULT (getdate()) NOT NULL,
    [UserIdNo]        SMALLINT       NULL,
    [DateTimeStamp]   ROWVERSION     NOT NULL,
    CONSTRAINT [PK_SalesIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

