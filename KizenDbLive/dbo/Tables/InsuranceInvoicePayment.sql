CREATE TABLE [dbo].[InsuranceInvoicePayment] (
    [ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [InsuranceCompanyID] INT             NULL,
    [CreatedDateTime]    DATETIME        NULL,
    [DateTime]           DATETIME        NULL,
    [Amount]             DECIMAL (18, 2) NULL,
    [Method]             NVARCHAR (50)   NULL,
    [BankID]             INT             NULL,
    [BoxId]              INT             NULL,
    [Note]               NVARCHAR (MAX)  NULL,
    [UserID]             INT             NOT NULL,
    [ReceiptNumber]      NVARCHAR (255)  NULL,
    CONSTRAINT [PK_InsuranceInvoicePayment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

