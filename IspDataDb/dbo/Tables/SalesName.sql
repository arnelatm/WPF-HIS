CREATE TABLE [dbo].[SalesName] (
    [IdNo]      NCHAR (10)    NOT NULL,
    [InvoiceNo] INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SalesName] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

