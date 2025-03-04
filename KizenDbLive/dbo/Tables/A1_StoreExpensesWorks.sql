CREATE TABLE [dbo].[A1_StoreExpensesWorks] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Code]       NVARCHAR (MAX) NULL,
    [SourceCode] NVARCHAR (MAX) NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [OrderID]    INT            NULL,
    CONSTRAINT [PK_A1_StoreExpensesWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

