CREATE TABLE [dbo].[JTX_Company] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Code]            NVARCHAR (50)  NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    [NameLatin]       NVARCHAR (200) NULL,
    [VatNumber]       NVARCHAR (150) NULL,
    [Disabled]        BIT            NOT NULL,
    [DateFilterType]  INT            NOT NULL,
    [LinkedWithZatca] BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JTX_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JTX_Company]([Name] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JTX_Company]([Code] ASC);

