CREATE TABLE [dbo].[JC_CD_TemplateDocument] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [CreatedDateTime]  DATETIME        NOT NULL,
    [TemplateId]       INT             NOT NULL,
    [SourceId]         INT             NULL,
    [Data]             VARBINARY (MAX) NULL,
    [Description]      NVARCHAR (MAX)  NULL,
    [CreateUserId]     INT             NULL,
    [CreateUserName]   NVARCHAR (255)  NULL,
    [LastEditDateTime] DATETIME        NULL,
    [LastEditUserId]   INT             NULL,
    [LastEditUserName] NVARCHAR (255)  NULL,
    CONSTRAINT [PK_dbo.JC_CD_TemplateDocument] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_CD_TemplateDocument_dbo.JC_CD_Template_TemplateId] FOREIGN KEY ([TemplateId]) REFERENCES [dbo].[JC_CD_Template] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TemplateId]
    ON [dbo].[JC_CD_TemplateDocument]([TemplateId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceId]
    ON [dbo].[JC_CD_TemplateDocument]([SourceId] ASC);

