CREATE TABLE [dbo].[JC_CD_Category] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [NameLatin] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.JC_CD_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

