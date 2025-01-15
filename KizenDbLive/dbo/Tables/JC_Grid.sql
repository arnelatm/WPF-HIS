CREATE TABLE [dbo].[JC_Grid] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [SystemId] SMALLINT       NOT NULL,
    [Name]     NVARCHAR (500) NOT NULL,
    [Type]     SMALLINT       NOT NULL,
    CONSTRAINT [PK_dbo.JC_Grid] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId]
    ON [dbo].[JC_Grid]([SystemId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemAndNameAndType]
    ON [dbo].[JC_Grid]([SystemId] ASC, [Name] ASC, [Type] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JC_Grid]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Type]
    ON [dbo].[JC_Grid]([Type] ASC);

