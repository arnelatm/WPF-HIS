CREATE TABLE [dbo].[JAC_Currency] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Part]       NVARCHAR (50) NULL,
    [Conversion] INT           NOT NULL,
    [Symbol]     NVARCHAR (15) NULL,
    [NameLatin]  NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.JAC_Currency] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Currency]([Name] ASC);

