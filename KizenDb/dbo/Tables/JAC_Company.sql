CREATE TABLE [dbo].[JAC_Company] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (250)  NOT NULL,
    [Code]             NVARCHAR (50)   NOT NULL,
    [NameLatin]        NVARCHAR (250)  NULL,
    [HeaderImageBytes] VARBINARY (MAX) NULL,
    [FooterImageBytes] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.JAC_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Company]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JAC_Company]([Name] ASC);

