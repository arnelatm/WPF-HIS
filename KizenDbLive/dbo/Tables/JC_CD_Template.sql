CREATE TABLE [dbo].[JC_CD_Template] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (50)   NOT NULL,
    [TitleLatin]       NVARCHAR (50)   NULL,
    [Description]      NVARCHAR (MAX)  NULL,
    [DescriptionLatin] NVARCHAR (MAX)  NULL,
    [SourceType]       NVARCHAR (50)   NOT NULL,
    [Data]             VARBINARY (MAX) NULL,
    [Status]           INT             NOT NULL,
    [SourceSubType]    NVARCHAR (50)   NULL,
    [CategoryId]       INT             NULL,
    CONSTRAINT [PK_dbo.JC_CD_Template] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_CD_Template_dbo.JC_CD_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[JC_CD_Category] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_SourceType]
    ON [dbo].[JC_CD_Template]([SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceSubType]
    ON [dbo].[JC_CD_Template]([SourceSubType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [dbo].[JC_CD_Template]([CategoryId] ASC);

