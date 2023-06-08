CREATE TABLE [dbo].[Sale] (
    [IdNo]            INT        IDENTITY (1, 1) NOT NULL,
    [PatientIdNo]     INT        NULL,
    [CustomerIdNo]    INT        NULL,
    [TransactionDate] DATE       NULL,
    [Cash]            BIT        NULL,
    [Amount]          MONEY      NOT NULL,
    [DueDate]         DATE       NULL,
    [InvoiceNo]       INT        NULL,
    [VatAmount]       MONEY      NULL,
    [WarehouseIdNo]   SMALLINT   NULL,
    [Posted]          BIT        NULL,
    [Cancelled]       BIT        NULL,
    [DateCreated]     DATETIME   CONSTRAINT [DF_SalesDateCreated] DEFAULT (getdate()) NOT NULL,
    [UserIdNo]        SMALLINT   NULL,
    [DateTimeStamp]   ROWVERSION NOT NULL,
    CONSTRAINT [PK_SalesIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

