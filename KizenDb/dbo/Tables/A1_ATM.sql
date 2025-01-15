CREATE TABLE [dbo].[A1_ATM] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Banck]   NVARCHAR (50) NULL,
    [Percent] INT           NULL,
    CONSTRAINT [PK_A1_ATM] PRIMARY KEY CLUSTERED ([ID] ASC)
);

