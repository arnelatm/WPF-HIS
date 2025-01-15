CREATE TABLE [dbo].[A1_ExpensesCatag] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    [Parent] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_A1_ExpensesCatag] PRIMARY KEY CLUSTERED ([ID] ASC)
);

