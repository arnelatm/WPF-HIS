CREATE TABLE [dbo].[A1_ExpensesInvoices] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [ExpenseID]       INT             NULL,
    [SourceType]      NVARCHAR (50)   NULL,
    [SourceID]        NVARCHAR (255)  NULL,
    [SourceInvoiceID] NVARCHAR (255)  NULL,
    [Value]           DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_A1_ExpensesInvoices] PRIMARY KEY CLUSTERED ([ID] ASC)
);

